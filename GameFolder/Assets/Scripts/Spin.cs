using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public Rigidbody2D rb;
    public float torque;
    void Start()
    {
      rb.AddTorque(torque, ForceMode2D.Impulse);
    }

}
