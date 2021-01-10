using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class letterChanger : MonoBehaviour
{
    public Color color;
    public Text w;
    public Text a;
    public Text s;
    public Text d;

    private bool W;
    private bool A;
    private bool S;
    private bool D;

    public TutorialManager tutorialManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            w.color = color;
            W = true;
        }
        if (Input.GetKeyDown("a"))
        {
            a.color = color;
            A = true;
        }
        if (Input.GetKeyDown("s"))
        {
            s.color = color;
            S = true;
        }
        if (Input.GetKeyDown("d"))
        {
            d.color = color;
            D = true;
        }

        if(W && A && S && D)
        {
            tutorialManagerScript.sequencePassed = true;
        }
    }
}
