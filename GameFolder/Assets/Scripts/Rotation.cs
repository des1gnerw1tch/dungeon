using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Rotation : MonoBehaviour
{

    private Transform player;
    private Transform Obj;
    public GameObject miniMapArrow;
    private bool hasLooked = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //Obj = GameObject.FindGameObjectWithTag("ObjMarker").transform;
    }

    // Update is called once per frame
    void Update()
    {
       

        if(GameObject.FindGameObjectWithTag("ObjMarker") != null)
        {
            
            Obj = GameObject.FindGameObjectWithTag("ObjMarker").transform;

            Vector2 lookDir = player.position - Obj.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90;
            transform.eulerAngles = new Vector3(0, 0, angle);
            if (Vector3.Distance(player.position, Obj.position) <= 22)
            {
                miniMapArrow.SetActive(false);
            }
            else
            {
                miniMapArrow.SetActive(true);
            }

        }
        else
        {
            miniMapArrow.SetActive(false);
            
        }
    }
}
