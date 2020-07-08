using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;

    void Start()
    {

      rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D coll) {

      if (coll.gameObject.CompareTag("Weapon"))  {
        BulletHit bullet = coll.GetComponent<BulletHit>();
        if (bullet != null) {
          int thrust = bullet.GetKnockback();
          Vector2 difference = transform.position - coll.transform.position;
          difference = difference.normalized * thrust;
          rb.AddForce(difference, ForceMode2D.Impulse);
        }
      }

    }

}
