using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class MultisoundEmitter : MonoBehaviour {
    public AudioClip[] clips;

    private AudioSource source;
    private Dictionary<string, AudioClip> clipsDict;
	// Use this for initialization
	void Start () {
        source = (AudioSource)gameObject.GetComponent(typeof(AudioSource));
        clipsDict = new Dictionary<string, AudioClip>();

        for (int i = 0; i < clips.Length; ++i)
        {
            clipsDict.Add(clips[i].name, clips[i]);
        }
	}

    public void PlaySound(string p_soundName, float volume = 1.0f, ulong delay = 0)
    {
        if (clipsDict.ContainsKey(p_soundName))
        {
            source.clip = clipsDict[p_soundName];
            source.volume = volume;
            source.Play(delay);
        }

        else
        {
            Debug.Log("Can't find sound named " + p_soundName);
        }
    }
}
