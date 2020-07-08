using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGun : MonoBehaviour
{
      public void DropGun()
    {

          foreach(Transform child in transform){
            if (child.gameObject != null) {
              GameObject.Destroy(child.gameObject);

          }
        }
	}

}
