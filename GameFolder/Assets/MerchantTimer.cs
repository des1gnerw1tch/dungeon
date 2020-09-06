using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantTimer : MonoBehaviour
{
    public float counter;

    void Start()
    {
      counter = 0f;
    }

    // Update is called once per frame
    void Update()
    {
      counter += Time.deltaTime;
    }

    public void ResetTimer()  {
      counter = 0f;
    }
}
