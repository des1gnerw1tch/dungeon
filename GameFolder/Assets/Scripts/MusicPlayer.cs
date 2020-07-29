using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public string themeName;
    public float timeBeforeStart;
    private bool playing;
    private float counter;
    // Start is called before the first frame update
    void Start()
    {
      counter = timeBeforeStart;
    }

    // Update is called once per frame
    void Update()
    {
      //will play music after timeBeforeStart is reached
      if (!playing) {
        if (counter > 0)  {
          counter-= Time.deltaTime;
        } else {
            FindObjectOfType<AudioManager>().PlayTheme(themeName);
            playing = true;
            return;
        }
      }

    }

}
