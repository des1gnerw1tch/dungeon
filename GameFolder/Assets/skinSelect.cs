﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Animations;

public class skinSelect : MonoBehaviour
{
    [SerializeField] private Sprite bobSprite;
    [SerializeField] private RuntimeAnimatorController bobAnimator;

    [SerializeField] private Sprite zachSprite;
    [SerializeField] private RuntimeAnimatorController zachAnimator;

    // Start is called before the first frame update
    void Start()
    {
      UpdateCharacterSkin();
    }

    void UpdateCharacterSkin()  {

      if (PlayerSettings.character == "Bob")  {
        GetComponent<SpriteRenderer>().sprite = bobSprite;
        GetComponent<Animator>().runtimeAnimatorController = bobAnimator;
      }

      if (PlayerSettings.character == "Zach")  {
        GetComponent<SpriteRenderer>().sprite = zachSprite;
        GetComponent<Animator>().runtimeAnimatorController = zachAnimator;
      }

    }
}
