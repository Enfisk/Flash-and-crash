using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerCollision : MonoBehaviour {
    private MultisoundEmitter soundScript;
    private PlayerMovement movementScript;
    private FlickeringLight flickerScript;
    
	// Use this for initialization
	void Start () {
        soundScript     = (MultisoundEmitter)GetComponent(typeof(MultisoundEmitter));
        movementScript  = (PlayerMovement)GetComponent(typeof(PlayerMovement));
        flickerScript   = (FlickeringLight)GetComponent(typeof(FlickeringLight));
	}

    void OnCollisionEnter(Collision p_collision)
    {
        if (p_collision.gameObject.tag.Contains("ball") || p_collision.gameObject.tag == "wall")
        {
            soundScript.PlaySound("impact", (rigidbody.velocity.magnitude / movementScript.maxSpeed) >= 0.5f ? (rigidbody.velocity.magnitude / movementScript.maxSpeed) : 0.5f);
            StartCoroutine(flickerScript.FlickerLights());
        }
    }
}
