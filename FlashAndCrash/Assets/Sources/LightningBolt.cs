/*
	This script is placed in public domain. The author takes no responsibility for any possible harm.
	Contributed by Jonathan Czeck
*/
using UnityEngine;
using System.Collections;

public class LightningBolt : MonoBehaviour
{
	private Transform target;
	public int zigs = 100;
	public float speed = 1f;
	public float scale = 1f;
	public Light startLight;
	public Light endLight;
	
	Perlin noise;
	float oneOverZigs;
	
	private Particle[] particles;
    private bool teslaEntered = false;
	
	void Start()
	{
        GameObject go = new GameObject();
        go.transform.parent = transform;
        go.transform.localPosition = new Vector3(0f, 0f, 0f);
        target = go.transform;

		oneOverZigs = 1f / (float)zigs;
		particleEmitter.emit = false;

		particleEmitter.Emit(zigs);
		particles = particleEmitter.particles;
	}

    void OnTriggerEnter(Collider p_collider)
    {
        if (!teslaEntered && p_collider.gameObject.tag == "tesla")
        {
            target = p_collider.gameObject.transform;
            teslaEntered = true;
        }
    }

    void OnTriggerExit(Collider p_collider)
    {
        if (teslaEntered && p_collider.gameObject.tag == "tesla")
        {
            GameObject go = new GameObject();
            go.transform.parent = transform;
            go.transform.localPosition = new Vector3(0f, 0f, 0f);
            target = go.transform;
            teslaEntered = false;
        }
    }
	
	void Update ()
	{
		if (noise == null)
			noise = new Perlin();

        if (!teslaEntered)
        {
            target.localPosition = new Vector3(0f + Random.Range(-3f, 3f), 0f + Random.Range(-1.5f, 3f), 0f + Random.Range(-3f, 3f));
        }
			
		float timex = Time.time * speed * 0.1365143f;
		float timey = Time.time * speed * 1.21688f;
		float timez = Time.time * speed * 2.5564f;
		
		for (int i=0; i < particles.Length; i++)
		{
			Vector3 position = Vector3.Lerp(transform.position, target.position, oneOverZigs * (float)i);
			Vector3 offset = new Vector3(noise.Noise(timex + position.x, timex + position.y, timex + position.z),
										noise.Noise(timey + position.x, timey + position.y, timey + position.z),
										noise.Noise(timez + position.x, timez + position.y, timez + position.z));
			position += (offset * scale * ((float)i * oneOverZigs));
			
			particles[i].position = position;
			particles[i].color = Color.white;
			particles[i].energy = 1f;
		}
		
		particleEmitter.particles = particles;
		
		if (particleEmitter.particleCount >= 2)
		{
			if (startLight)
				startLight.transform.position = particles[0].position;
			if (endLight)
				endLight.transform.position = particles[particles.Length - 1].position;
		}
	}	
}