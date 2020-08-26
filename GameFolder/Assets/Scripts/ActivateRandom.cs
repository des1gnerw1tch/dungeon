using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRandom : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objs;
    // Start is called before the first frame update
    void Start()
    {
      int num = Random.Range(0, objs.Length);
      objs[num].SetActive(true);
    }

}
