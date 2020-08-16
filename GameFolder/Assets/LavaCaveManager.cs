using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaCaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      /*turns off the power in the lava dungeon if turned on, this is here to make sure that
      when you leave the dungeon scene, lava dung progress is reset. */
      LavaDungManager.powerOn = false;
      FindObjectOfType<AudioManager>().Stop("siren");
    }
}
