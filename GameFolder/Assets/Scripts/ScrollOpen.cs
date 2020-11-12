using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollOpen : MonoBehaviour
{

    private GameObject Panal;
    private bool Open;
    public string text;
    // Start is called before the first frame update
    void Start()
    {
        Panal = GameObject.Find("ScrollPanal");
        Panal.GetComponentInChildren<Text>().text = text;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown("e")) && !Open)
        {
            Panal.GetComponent<CanvasGroup>().alpha = 1;
            Open = true;
        }else if((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown("e")) && Open)
        {
            Panal.GetComponent<CanvasGroup>().alpha = 0;
            Open = false;
        }
    }
}
