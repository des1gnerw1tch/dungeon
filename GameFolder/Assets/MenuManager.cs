using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
  [SerializeField]
  private Animator animator;
  [SerializeField]
  private GameObject mainUI;

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

}
