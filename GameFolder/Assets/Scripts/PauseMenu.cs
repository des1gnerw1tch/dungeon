using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
        FindObjectOfType<ItemManager>().enabled = true;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
        FindObjectOfType<ItemManager>().enabled = false;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;

        /*destroys all old objects, destroys animators first because there was a null problem
        where animators were trying to access already deleted objects!*/
        Animator[] animators = UnityEngine.Object.FindObjectsOfType<Animator>();
        foreach(Animator anim in animators)  {
          Destroy(anim.gameObject);
        }

        DontDestroy[] objects = UnityEngine.Object.FindObjectsOfType<DontDestroy>();
        foreach(DontDestroy obj in objects)  {
          Destroy(obj.gameObject);
        }

        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game... ");
        Application.Quit();

    }
}
