using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class vault : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool vaultActivated = false;
    public GameObject vaultCanvas;
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown("e") && other.CompareTag("Player"))
        {
            if (vaultActivated)
            {
                //Close();
            }
            else
            {
                Open();
            }
        }
    }
    /*void Update()
    {
        if (vaultActivated && Input.GetKeyDown("e"))
        {
            Close();
        }
    }*/
    void Open()
    {
        vaultCanvas.SetActive(true);
        Time.timeScale = 0f;
        vaultActivated = true;
        FindObjectOfType<ItemManager>().useDisabled = true;
    }
    public void Close()
    {
        vaultCanvas.SetActive(false);
        Time.timeScale = 1;
        vaultActivated = false;
        FindObjectOfType<ItemManager>().useDisabled = false;
    }
}
