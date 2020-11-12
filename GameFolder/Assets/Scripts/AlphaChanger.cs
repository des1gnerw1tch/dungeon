using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaChanger : MonoBehaviour
{
    public GameObject DropDown;
    private float num = 2;
    // Start is called before the first frame update
    void Start()
    {
       
        if(!GameObject.FindObjectOfType<PlayerHealth>().transported)
        {
            GetComponent<CanvasGroup>().alpha = 0;
        }
        else
        {
            DropDown.SetActive(false);
        }
    }

    private void Update()
    {
        if (GameObject.FindObjectOfType<PlayerHealth>() != null)
        {
            if (GameObject.FindObjectOfType<PlayerHealth>().transported)
            {
                
                if(num >= 0)
                {
                    num = num - Time.deltaTime;
                }
                else
                {
                    GetComponent<CanvasGroup>().alpha = GetComponent<CanvasGroup>().alpha - Time.deltaTime / 5;
                }
                GameObject.FindObjectOfType<PlayerMovement>().moveSpeed = 0f;
            }
            if(GetComponent<CanvasGroup>().alpha == 0)
            {
                GameObject.FindObjectOfType<PlayerHealth>().transported = false;
                GameObject.FindObjectOfType<PlayerMovement>().moveSpeed = 5f;
            }

        }
    }


}
