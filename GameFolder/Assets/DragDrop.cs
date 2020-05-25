using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private GameObject item;
    private RectTransform itemPos;
    private Slot slot;
    public Inventory inventory;
    public DragInstance dragInstance;

    void Awake()  {
      slot = GetComponent<Slot>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
      if (transform.childCount > 0)  {
        dragInstance.itemDragging = this.transform.GetChild(0).gameObject;      
      }
      dragInstance.slotDragging = GetComponent<Slot>();


    }

    public void OnDrag(PointerEventData eventData) {
  /*    try {
        itemPos.anchoredPosition += eventData.delta/ (canvas.scaleFactor/2);
      }
      catch (MissingReferenceException e){
        //item was dropped when holding
      }*/

    }

    public void OnEndDrag(PointerEventData eventData) {
      Debug.Log("end drag");
    //  transform.DetachChildren();

      //if not touching slots, drops item
      /*
        inventory.item[slot.i] = null;
        slot.DropItem();
        */

    }

    public void OnPointerDown(PointerEventData eventData) {
      Debug.Log("pointing? ");
    }


}
