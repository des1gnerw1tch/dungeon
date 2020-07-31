using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onOffController : MonoBehaviour
{
    [SerializeField]
    private GameObject musicOn;
    [SerializeField]
    private GameObject musicOff;

    [SerializeField]
    private GameObject sfxOn;
    [SerializeField]
    private GameObject sfxOff;

    [SerializeField]
    private GameObject fancyLightingOn;
    [SerializeField]
    private GameObject fancyLightingOff;

    void Start()
    {

      if (PlayerSettings.music) {
        musicOn.SetActive(true);
        musicOff.SetActive(false);
      } else {
        musicOn.SetActive(false);
        musicOff.SetActive(true);
      }

      if (PlayerSettings.soundEffects) {
        sfxOn.SetActive(true);
        sfxOff.SetActive(false);
      } else {
        sfxOn.SetActive(false);
        sfxOff.SetActive(true);
      }

      if (PlayerSettings.fancyGraphics) {
        fancyLightingOn.SetActive(true);
        fancyLightingOff.SetActive(false);
      } else {
        fancyLightingOn.SetActive(false);
        fancyLightingOff.SetActive(true);
      }

    }

    public void ClickMusic()  {

      if (PlayerSettings.music) {
        musicOn.SetActive(false);
        musicOff.SetActive(true);
        PlayerSettings.music = false;
        //will stop current menu music
        FindObjectOfType<AudioManager>().Stop(FindObjectOfType<MusicPlayer>().themeName);
      } else {
        musicOn.SetActive(true);
        musicOff.SetActive(false);
        PlayerSettings.music = true;
        //will start menu music up
        FindObjectOfType<AudioManager>().PlayTheme(FindObjectOfType<MusicPlayer>().themeName);
      }
      SaveSystem.SaveSettings();

    }

    public void ClickSoundSfx() {

      if (PlayerSettings.soundEffects) {
        sfxOn.SetActive(false);
        sfxOff.SetActive(true);
        PlayerSettings.soundEffects = false;
      } else {
        sfxOn.SetActive(true);
        sfxOff.SetActive(false);
        PlayerSettings.soundEffects = true;
      }
      SaveSystem.SaveSettings();

    }

    public void ClickFancyGraphics() {

      if (PlayerSettings.fancyGraphics) {
        fancyLightingOn.SetActive(false);
        fancyLightingOff.SetActive(true);
        PlayerSettings.fancyGraphics = false;
      } else {
        fancyLightingOn.SetActive(true);
        fancyLightingOff.SetActive(false);
        PlayerSettings.fancyGraphics = true;
      }
      SaveSystem.SaveSettings();

    }
}
