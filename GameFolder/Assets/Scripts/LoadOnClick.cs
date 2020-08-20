using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class LoadOnClick : MonoBehaviour
{

    [SerializeField]
    private MenuManager menuManager;
    [SerializeField]
    private float delay;
    [SerializeField]
    private GameObject noSaveUI;


    public void Click()  {
      string path = Application.persistentDataPath + "/player.fun";
      if (File.Exists(path))  {
        menuManager.PlaySave(delay);
      } else {
        noSaveUI.SetActive(true);
      }

    }


}
