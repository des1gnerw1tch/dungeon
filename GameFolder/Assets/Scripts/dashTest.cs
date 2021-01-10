using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dashTest : MonoBehaviour
{
    public Text shift;
    public Color color;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shift.color = color;
            FindObjectOfType<TutorialManager>().sequencePassed = true;
        }
    }
}
