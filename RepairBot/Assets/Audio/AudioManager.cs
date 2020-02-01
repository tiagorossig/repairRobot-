using System;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    
    
    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
        StartGameMusic();
    }

    public void StartGameMusic()
    {
        Play("Head");
        Play("Torso");
    }
    
    public void Play(string soundName) // for playing general sounds
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        s.source.Play();
    }


    public IEnumerator AddTheme(string soundName) // for adding parts of the main theme when picking up parts
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);

        while (s.volume < 1)
        {
            s.volume += .1f;
            yield return new WaitForSeconds(.5f);
        }
    }
    
}
