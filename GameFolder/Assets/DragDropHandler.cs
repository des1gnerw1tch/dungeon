using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropHandler : MonoBehaviour, IDropHandler
{
    GameObject itemDropping;
    GameObject newItem;
    public Inventory inventory;

    public void OnDrop(PointerEventData eventData)  {
      Debug.Log("Dropped on slot");
      if (eventData.pointerDrag != null)  {
        itemDropping = eventData.pointerDrag.transform.GetChild(0).gameObject;
      //  transform.DetachChildren();
        //Destroy(itemDropping);
        
        Instantiate(itemDropping, transform, false);

    //  inventory.item[i] = inventoryID;
        //itemDropping.transform.SetParent(transform, true);
    //    itemDropping.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
      }
    }

}
