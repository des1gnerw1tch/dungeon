using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractaceManager : MonoBehaviour
{
    public int numTurn;
    public bool isWaiting;
    public bool secondHalf;
    public float seconds = 1.7f;
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
        if(seconds> 1f)
        {
            yield return new WaitForSeconds(seconds);
            seconds -= .1f;
        }
        else
        {
            yield return new WaitForSeconds(1f);
        }
        secondHalf = true;
        yield return new WaitForSeconds(.5f);
        secondHalf = false;
        isWaiting = false;
        numTurn = Random.Range(0, 5);
    }
}
