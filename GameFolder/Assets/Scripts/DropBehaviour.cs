using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropBehaviour  {

  public GameObject item;
  [Range(0f, 1f)]
  public float probability;
  public int low;
  public int high;

}
