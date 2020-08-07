using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class Casting : MonoBehaviour
{
    private GameObject Panal;
    //public GameObject spell;
    public bool started = false;
    private ItemManager itemManagerScript;
    public ParticleSystem system;
    
    // Start is called before the first frame update
    void Start()
    {
        itemManagerScript = GameObject.Find("ItemManager").GetComponent<ItemManager>();
        Panal = GameObject.Find("EnchantingPanal");
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey("e") && !started && itemManagerScript.itemString == "EmptyBook") 
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().moveSpeed = 0;
                Group(1,true,true);
                started = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if ((Input.GetKey("r") && started) || Panal.GetComponent<LineJumper>().isSuccess)
        {
            Vector3 move = new Vector3(0, 1, 0);
            if (started && Panal.GetComponent<LineJumper>().isSuccess)
            {
                //Instantiate(spell, GameObject.FindGameObjectWithTag("Player").transform.position + move, Quaternion.identity);
                system.Play();
            } 
            started = false;
            Panal.GetComponent<LineJumper>().isSuccess = false;
            Panal.GetComponent<LineJumper>().clearLines();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().moveSpeed = 5;
            Group(0, false, false);
        }

    }
    public void Group(int alpha, bool inter , bool ray)
    {
        Panal.GetComponent<CanvasGroup>().alpha = alpha;
        Panal.GetComponent<CanvasGroup>().interactable = inter;
        Panal.GetComponent<CanvasGroup>().blocksRaycasts = ray;
    }
}