using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCompletedPop : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject text;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //show dungeon completed UI is broken in build. 
    public void ShowDungeonCompleted() {
      //text.SetActive(true);
    }
}
