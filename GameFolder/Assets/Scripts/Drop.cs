using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Drop {
    // Start is called before the first frame update
    public string name;
    public float force;
    public DropBehaviour[] itemType;
    /*public GameObject[] items;
    [Range(0f, 1f)]
    public float[] dropProbability;
    public int[] numOfItemDropped;*/

}
