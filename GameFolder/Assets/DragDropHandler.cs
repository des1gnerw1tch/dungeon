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
      /*if (eventData.pointerDrag != null)  {

      }*/
      Instantiate(dragInstance.itemDragging, transform, false);
      dragInstance.slotDragging.transform.DetachChildren();

      //switches object, old slot
      if (transform.childCount > 1) {
        itemSwitching = this.transform.GetChild(0).gameObject;
        Instantiate(itemSwitching, dragInstance.slotDragging.transform, false);
        itemSwitching.transform.parent = null;
      }

      //dragInstance.slotDragging.transform.DetachChildren();
    }

}
