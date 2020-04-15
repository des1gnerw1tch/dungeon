using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedGun : MonoBehaviour
{
    private Transform firepointPos;
    public GameObject GunPrefab;
    public bool isEquipped;
    public void Start()
    {
        firepointPos = GameObject.FindGameObjectWithTag("FirePoint").transform;
        Vector2 Pos = new Vector2(firepointPos.position.x, firepointPos.position.y);
        GunPrefab = Instantiate(GunPrefab, Pos,firepointPos.rotation);
        isEquipped = true;
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
