using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayerNew : MonoBehaviour {
    public AudioSource source;

	// Update is called once per frame
	void Update () {
        if (audio)
        {
            if (!audio.isPlaying)
            {
                audio.time = 24.0f;
                audio.Play();
            }
        }
	}
}
