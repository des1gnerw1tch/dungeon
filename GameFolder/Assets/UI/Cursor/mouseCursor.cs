using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCursor : MonoBehaviour
{

    // Update is called once per frame
    public Animator animator;
    public Renderer sprite;
    void Start()  {
      Cursor.visible = false;
    }
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        if (Input.GetMouseButtonDown(0))  {
           animator.SetBool("pressed", true);
        }
        if (Input.GetMouseButtonUp(0))  {
           animator.SetBool("pressed", false);
        }

      /*  if (Input.GetAxisRaw("Mouse X") != 0|| Input.GetAxisRaw("Mouse Y") != 0) {
          sprite.enabled = true;
        } else {
          sprite.enabled = false;
        }*/

        //Debug.Log(Input.GetAxisRaw("Mouse X"));
    }
}
