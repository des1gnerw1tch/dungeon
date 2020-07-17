using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractace : MonoBehaviour
{
    public GameObject lights;
    public TargetPractaceManager TargetPractaceManagerScript;
    public static int counter;
    public static bool IsLit;
    public int ID;
    //public int randomNumber;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CrystalShot") && IsLit)
        {
            counter++;
            Debug.Log("counter");
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
        if(TargetPractaceManagerScript.numTurn == ID){
            lights.SetActive(true);
            //IsLit = true;
        }
        else
        {
            lights.SetActive(false);
        }
    }
    //public void ChooseNumber(){
     //   randomNumber = Random.Range(0, 5); 
    //}
}
