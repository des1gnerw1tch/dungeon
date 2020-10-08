using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingsData {
  public bool soundEffects;
  public bool music;
  public bool fancyGraphics;
  public string character;

  //constructor
  public SettingsData ()  {
    soundEffects = PlayerSettings.soundEffects;
    music = PlayerSettings.music;
    fancyGraphics = PlayerSettings.fancyGraphics;
    character = PlayerSettings.character;
  }
}
