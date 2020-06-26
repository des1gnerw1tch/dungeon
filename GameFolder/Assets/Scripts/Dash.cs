using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashTime = 1f;
    public float dashCooldown = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("left shift") && dashCooldown<= 0f){

            //Vector2 dir = PlayerMovement.getMovement();
        }
        
    }
}
