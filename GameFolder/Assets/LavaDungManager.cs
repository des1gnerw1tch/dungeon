using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDungManager : MonoBehaviour
{
    [SerializeField] GameObject removableLava;
    // Start is called before the first frame update
    void Start()
    {
        //BuildBridge();
    }


    void BuildBridge() {
      removableLava.SetActive(false);
    }
}
