using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerCollision : MonoBehaviour {
    public float lightDuration = 0.5f;

    private MultisoundEmitter soundScript;
    private PlayerMovement movementScript;
    private bool lightDisabled = false;
    private float lightTimer;
    
	// Use this for initialization
	void Start () {
        soundScript = (MultisoundEmitter)gameObject.GetComponent(typeof(MultisoundEmitter));
        movementScript = (PlayerMovement)gameObject.GetComponent(typeof(PlayerMovement));
	}

    void OnCollisionEnter(Collision p_collision)
    {
        if (p_collision.gameObject.tag.Contains("ball") || p_collision.gameObject.tag == "wall")
        {
            soundScript.PlaySound("impact", (rigidbody.velocity.magnitude / movementScript.maxSpeed) >= 0.5f ? (rigidbody.velocity.magnitude / movementScript.maxSpeed) : 0.5f);
            light.enabled = false;
            lightDisabled = true;
            lightTimer = 0.0f;
        }
    }

    void Update()
    {
        if (lightDisabled)
        {
            lightTimer += Time.deltaTime;

            if (lightTimer >= lightDuration)
            {
                light.enabled = true;
                lightDisabled = false;
            }
        }
    }
}
