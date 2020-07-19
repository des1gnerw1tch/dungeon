using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSlot : MonoBehaviour
{
    [SerializeField]
    private int num;
    [SerializeField]
    private DeathInventory deathInventory;

    public void Click()  {
      deathInventory.SlotClick(num);
    }
}
