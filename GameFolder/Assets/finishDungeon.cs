using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishDungeon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<DungeonCompletedPop>().ShowDungeonCompleted();
    }
}
