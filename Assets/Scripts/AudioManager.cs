using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource[] sources;


    private void Awake()
    {
        sources = GetComponentsInChildren<AudioSource>();
    }
    
    public AudioSource PlaySound(string soundName, float volume = 1f)
    {
        foreach (var source in sources)
        {
            if (source.clip.name.Equals(soundName))
            {
                source.volume = volume;
                source.loop = false;
                source.Play();

                return source;
            }
        }

        Debug.LogError("Can't find " + soundName + " sound");
        return null;
    }
}
