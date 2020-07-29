﻿using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
      foreach (Sound s in sounds) {
        s.source = gameObject.AddComponent<AudioSource>();
        s.source.clip = s.clip;
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
        s.source.loop = s.loop;
      }
    }

    //this is for sound effects
    public void Play(string name) {
      if (PlayerSettings.soundEffects)  {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        /*if (s.source = null)  {
          return;
        }*/
        s.source.Play();
      }
    }

    //this is to play music
    public void PlayTheme(string name) {
      if (PlayerSettings.music)  {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        /*if (s.source = null)  {
          return;
        }*/
        s.source.Play();
      }
    }

    public void Stop(string name) {
      Sound s = Array.Find(sounds, sound => sound.name == name);
      s.source.Stop();
    }
}
