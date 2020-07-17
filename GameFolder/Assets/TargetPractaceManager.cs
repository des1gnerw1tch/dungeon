using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractaceManager : MonoBehaviour
{
    public int numTurn;
    public bool isWaiting;
    void Update()
    {
        if (isWaiting)
        {
            Debug.Log(numTurn);
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
        yield return new WaitForSeconds(5);
        isWaiting = false;
        numTurn = Random.Range(0, 5);
    }
}
