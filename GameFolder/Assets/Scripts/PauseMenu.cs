using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameSaveManager GameManager;
    public GameObject[] keys;
    public GameObject[] completionTexts;
    public GameObject[] incompleteTexts;
    private GameObject ItemManager;
    private Inventory inventoryScript;
    private scroll scrollScript;
    private bool KeepItem = false;
    private void Start()
    {
        ItemManager = GameObject.Find("ItemManager");
        inventoryScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        scrollScript = GameObject.FindGameObjectWithTag("Player").GetComponent<scroll>();
    }
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
        ShowKeys();
        ShowCompletion();
        Time.timeScale = 0;
        GameIsPaused = true;
        FindObjectOfType<ItemManager>().enabled = false;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;

        /*destroys all old objects, destroys animators first because there was a null problem
        where animators were trying to access already deleted objects!*/
        if (PlayerProgress.blueCrystalDestroyed && PlayerProgress.redCrystalDestroyed && PlayerProgress.greenCrystalDestroyed)
        {
            KeepItem = true;
        }

        if (SceneManager.GetActiveScene().name == "3rdDoor")
        {

            for (int i = 0; i < inventoryScript.item.Length; i++)
            {
                if(inventoryScript.item[i] == "CrystalGauntletRed" && !KeepItem)
                {
                    scrollScript.activeSlot = i;
                    scrollScript.activeCanvasSlot.DestroyItem();
                    inventoryScript.item[i]= null;
                }
            }

        }
        GameManager.SavePlayer();
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

    void ShowKeys() {

      if (PlayerProgress.hasBlueKey)  {
        keys[0].SetActive(true);
      } else {
        keys[0].SetActive(false);
      }

      if (PlayerProgress.hasPurpleKey)  {
        keys[1].SetActive(true);
      } else {
        keys[1].SetActive(false);
      }

      if (PlayerProgress.hasBrownKey)  {
        keys[2].SetActive(true);
      } else {
        keys[2].SetActive(false);
      }

      if (PlayerProgress.hasCrystalKey)  {
        keys[3].SetActive(true);
      } else {
        keys[3].SetActive(false);
      }

    }



    void ShowCompletion() {
      if (PlayerProgress.nurseFreed)  {
        completionTexts[0].SetActive(true);
        incompleteTexts[0].SetActive(false);
      } else {
        completionTexts[0].SetActive(false);
        incompleteTexts[0].SetActive(true);
      }

      if (PlayerProgress.wizardFreed)  {
        completionTexts[1].SetActive(true);
        incompleteTexts[1].SetActive(false);
      } else {
        completionTexts[1].SetActive(false);
        incompleteTexts[1].SetActive(true);
      }

      if (PlayerProgress.alchemistFreed)  {
        completionTexts[2].SetActive(true);
        incompleteTexts[2].SetActive(false);
      } else {
        completionTexts[2].SetActive(false);
        incompleteTexts[2].SetActive(true);
      }

      if (PlayerProgress.friendFreed)  {
        completionTexts[3].SetActive(true);
        incompleteTexts[3].SetActive(false);
      } else {
        completionTexts[3].SetActive(false);
        incompleteTexts[3].SetActive(true);
      }

      if (PlayerProgress.blueCrystalDestroyed && PlayerProgress.redCrystalDestroyed && PlayerProgress.greenCrystalDestroyed)  {
        completionTexts[4].SetActive(true);
        incompleteTexts[4].SetActive(false);
      } else {
        completionTexts[4].SetActive(false);
        incompleteTexts[4].SetActive(true);
      }
    }
}
