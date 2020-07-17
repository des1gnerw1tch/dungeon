using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractaceManager : MonoBehaviour
{
    public int numTurn;
    public bool isWaiting;
    public bool secondHalf;
    void Update()
    {
        if (isWaiting)
        {
           
        }
        else
        {
            StartCoroutine(ChooseNumber());
        }
        
        /*Debug.Log(randomNumber);
        if (randomNumber == ID)
        {
            LightSpawn(ligthts);
            IsLit = true;
        }*/
    }
    IEnumerator ChooseNumber()
    {
        // suspend execution for 5 seconds
        isWaiting = true;
        yield return new WaitForSeconds(1.5f);
        secondHalf = true;
        yield return new WaitForSeconds(.5f);
        secondHalf = false;
        isWaiting = false;
        numTurn = Random.Range(0, 5);
    }
}
