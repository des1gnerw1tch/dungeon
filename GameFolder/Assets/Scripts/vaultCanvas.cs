using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaultCanvas : MonoBehaviour
{
    public vault vaultScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w")|| Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d"))
        {
            vaultScript.Close();
        }
    }
}
