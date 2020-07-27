using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuManager : MonoBehaviour
{
  [SerializeField]
  private Animator animator;
  [SerializeField]
  private GameObject mainUI;

  [SerializeField]
  private GameObject settingsUI;

  public void PlaySave(float delay)  {
    StartCoroutine(_PlaySave(delay));
  }


  IEnumerator _PlaySave(float _delay) {
    mainUI.SetActive(false);
    animator.SetTrigger("PlaySave");
    yield return new WaitForSeconds(_delay);
    SceneManager.LoadScene("Main");

  }

  public void NewGame(float delay)  {
    StartCoroutine(_NewGame(delay));
  }


  IEnumerator _NewGame(float _delay) {
    mainUI.SetActive(false);
    animator.SetTrigger("NewGame");
    yield return new WaitForSeconds(_delay);
    SceneManager.LoadScene("Main");
  }

  public void QuitGame()  {
    Debug.Log("Quitting Game");
    Application.Quit();
  }

  public void GoToSettings(float delay)  {
    animator.SetTrigger("Settings");
    mainUI.SetActive(false);
    StartCoroutine(_GoToSettings(delay));
  }

  IEnumerator _GoToSettings(float _delay) {
    yield return new WaitForSeconds(_delay);
    settingsUI.SetActive(true);
  }

  public void SettingsToMain(float delay) {
    animator.SetTrigger("SettingsToMain");
    settingsUI.SetActive(false);
    StartCoroutine(_SettingsToMain(delay));
  }

  IEnumerator _SettingsToMain(float _delay) {
    yield return new WaitForSeconds(_delay);
    mainUI.SetActive(true);
  }

}
