using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public string[] item;



    void Start() {
      item = new string[5];
      Debug.Log(item[0]);
    }

}
