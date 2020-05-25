using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropHandler : MonoBehaviour, IDropHandler
{
    private GameObject itemDropping;
    private GameObject itemSwitching;
    private GameObject newItem;
    public DragInstance dragInstance;
    public Inventory inventory;

    public void OnDrop(PointerEventData eventData)  {
      Debug.Log("Dropped on slot " + GetComponent<Slot>().i);
      Debug.Log("Came from slot " + dragInstance.slotDragging.i);
      //inventory
      string temp;
      temp = inventory.item[dragInstance.slotDragging.i];
      inventory.item[dragInstance.slotDragging.i] = inventory.item[GetComponent<Slot>().i];
      inventory.item[GetComponent<Slot>().i] = temp;


      //ui
      if (dragInstance.slotDragging.transform.childCount > 0) {
        Instantiate(dragInstance.itemDragging, transform, false);
        GameObject.Destroy(dragInstance.slotDragging.transform.GetChild(0).gameObject);
      }

      //switches object, old slot
      if (transform.childCount > 1) {
        itemSwitching = this.transform.GetChild(0).gameObject;
        Instantiate(itemSwitching, dragInstance.slotDragging.transform, false);
        GameObject.Destroy(itemSwitching);
      }

    }

}
