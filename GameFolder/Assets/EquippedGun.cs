using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedGun : MonoBehaviour
{
    private Transform firepointPos;
    public GameObject GunPrefab;
    GameObject Gun;
    public void Start()
    {
        firepointPos = GameObject.FindGameObjectWithTag("FirePoint").transform;
        Vector2 Pos = new Vector2(firepointPos.position.x, firepointPos.position.y);
        Gun = Instantiate(GunPrefab, Pos,firepointPos.rotation);
    }

    // Update is called once per frame
    public void Update()
    {
        firepointPos = GameObject.FindGameObjectWithTag("FirePoint").transform;
        Gun.transform.position = firepointPos.position;
        Gun.transform.rotation = firepointPos.rotation;
    }
}
