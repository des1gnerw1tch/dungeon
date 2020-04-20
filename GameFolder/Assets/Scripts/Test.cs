using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Tint tint;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.T))  {
        tint.SetTintColor(new Color(1, 1, 1, 1f));
      }
    }
}
