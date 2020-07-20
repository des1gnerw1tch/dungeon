using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnContact : MonoBehaviour
{
  [SerializeField]
  private GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D other)  {
      if (hitEffect != null)  {
        Instantiate(hitEffect, transform.position, Quaternion.identity);
      }
      Destroy(gameObject);
    }
}
