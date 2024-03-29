﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetPractaceManager : MonoBehaviour
{
    public int numTurn;
    public bool isWaiting;
    public bool secondHalf;
    public float seconds = 1.7f;
    public GameObject Water;
    public GameObject Tiles;
    public bool isDone = false;

    public int UInum;

    public Text text;
    void Update()
    {
        if (!isWaiting && !isDone)
        {
            StartCoroutine(ChooseNumber());
        }
        if (isDone)
        {
            Water.SetActive(false);
            Tiles.SetActive(true);

        }

        /*Debug.Log(randomNumber);
        if (randomNumber == ID)
        {
            LightSpawn(ligthts);
            IsLit = true;
        }*/
        text.text = UInum + "/10";
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
