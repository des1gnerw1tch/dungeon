using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class DropManager : MonoBehaviour
{
    public Drop[] drops;
    private Vector2 forceVector;

    void Start()
    {

    }

    public void Drop(string name, Vector3 pos) {
      //finding drop

      Drop dropName = Array.Find(drops, drop => drop.name == name);
      int arrayLength = dropName.itemType.Length;
      float force = dropName.force;

      //going through each drop behaviour

      foreach(DropBehaviour obj in dropName.itemType) {
        /*decides whether to drop or not,*/
        float num = Random.Range(0f, 1f);
        if (num <= obj.probability) {
          /*decides how many to drop*/
          int count = Random.Range(obj.low, obj.high + 1);

          for (int i = 0; i < count; i++) {
            /*instantiate the instance*/
            var instance = Instantiate(obj.item, pos, Quaternion.identity);
            Rigidbody2D objRB = instance.GetComponent<Rigidbody2D>();
            forceVector.Set(Random.Range(-force, force), Random.Range(-force, force));
      		  objRB.AddForce(forceVector, ForceMode2D.Impulse);
          }

        }

      }

    }
}
