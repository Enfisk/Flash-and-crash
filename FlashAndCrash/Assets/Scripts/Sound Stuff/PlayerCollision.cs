using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerCollision : MonoBehaviour {

    private MultisoundEmitter soundScript;
    private MovementTest1 movementScript;
	// Use this for initialization
	void Start () {
        soundScript = (MultisoundEmitter)gameObject.GetComponent(typeof(MultisoundEmitter));
        movementScript = (MovementTest1)gameObject.GetComponent(typeof(MovementTest1));
	}

    void OnCollisionEnter(Collision p_collision)
    {
        if (p_collision.gameObject.tag.Contains("ball") || p_collision.gameObject.tag == "wall")
        {
            soundScript.PlaySound("impact", (rigidbody.velocity.magnitude / movementScript.maxSpeed));
        }
    }
}
