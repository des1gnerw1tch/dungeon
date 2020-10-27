using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

    private GameObject Player;
    private ItemManager ItemManagerScript;
    public GameObject Drop;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        ItemManagerScript = FindObjectOfType<ItemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(ItemManagerScript.itemString == "Pickaxe" && Input.GetKeyDown(KeyCode.Mouse0))
            {
                
                FindObjectOfType<DropManager>().Drop("Gold", transform.position);
                Destroy(gameObject);
            }
        }
    }
}
