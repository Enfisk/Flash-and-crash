using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{

    private AudioSource[] sources = new AudioSource[2];
    private AudioClip clip;
    private float time = 0.0f;
    // Use this for initialization
    void Start()
    {
        clip = Resources.Load("Music/soundtrack_full") as AudioClip;

        foreach (AudioSource source in sources)
        {
            source.clip = clip;
            source.playOnAwake = false;
            source.loop = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (audio)
        {
            if (!audio.isPlaying || audio.time >= 98.0f)
            {
                audio.time = 24.0f;
                audio.Play();
            }
        }

        time = audio.time;
    }
}
