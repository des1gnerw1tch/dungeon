using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicPlayer : MonoBehaviour
{
    public string themeName;
    public float timeBeforeStart;
    private bool playing;
    private float counter;
    public static string songPlaying;
    // Start is called before the first frame update
    void Start()
    {
      counter = timeBeforeStart;

      if (themeName != songPlaying) {
        try {
          FindObjectOfType<AudioManager>().Stop(songPlaying);
        }
        catch (NullReferenceException e){
          //Debug.Log("No music found to stop");
        }
      }
    }

    // Update is called once per frame
    void Update()
    {
      //will play music after timeBeforeStart is reached
      if (themeName != songPlaying) {
      if (!playing) {
        if (counter > 0)  {
          counter-= Time.deltaTime;
        } else {
            FindObjectOfType<AudioManager>().PlayTheme(themeName);
            songPlaying = themeName;
            playing = true;
            return;
        }
      }
      }
    }

}
