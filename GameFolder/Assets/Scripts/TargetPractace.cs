using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractace : MonoBehaviour
{
    public GameObject lights;
    public TargetPractaceManager TargetPractaceManagerScript;
    public static int counter;
    public bool IsLit;
    public int ID;
    //public int randomNumber;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CrystalShot") && IsLit)
        {
            counter++;
            TargetPractaceManagerScript.UInum = counter;
            Debug.Log(counter);
        }
        
        if(other.CompareTag("CrystalShot") && !IsLit)
        {
            counter = 0;
            Debug.Log("you hit the wrong crystal restart " + counter);
        }
    }
    public void LightSpawn(GameObject lightSpawn) {
        //Instantiate(lightSpawn, transform.position, Quaternion.identity);
        lightSpawn.SetActive(true);
    }
    void Update()
    {
        //Invoke("ChooseNumber", 2f);
        //Debug.Log(randomNumber);
        if(TargetPractaceManagerScript.numTurn == ID && !TargetPractaceManagerScript.secondHalf){
            lights.SetActive(true);
            IsLit = true;
            //IsLit = true;
        }
        else
        {
            lights.SetActive(false);
            IsLit = false;
        }

        if(counter > 9)
        {
            TargetPractaceManagerScript.isDone = true;
            TargetPractaceManagerScript.isWaiting = true;
            lights.SetActive(true);
        }

    }
    //public void ChooseNumber(){
     //   randomNumber = Random.Range(0, 5); 
    //}
}
