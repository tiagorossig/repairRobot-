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
        StartGameMusic(); // ****Move to the Start of the main scene
    }

    public void StartGameMusic()
    {
        Play("Head");
        Play("Torso");
        Play("Arm1");
        Play("Arm2");
        Play("Leg1");
        Play("Leg2");
    }
    
    public void Play(string soundName) // for playing general sounds
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        s.source.Play();
    }


    public void AddTheme(string soundName)
    {
        StartCoroutine(VolumeIncrease(soundName));
    }

    public IEnumerator VolumeIncrease(string soundName) // for adding parts of the main theme when picking up parts
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);

        while (s.source.volume < .8)
        {
            s.source.volume += .02f;
            yield return new WaitForSeconds(.1f);
        }
    }
    
}
