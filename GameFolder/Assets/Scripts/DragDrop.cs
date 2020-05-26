using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Canvas canvas;

    private GameObject item;
    private RectTransform itemPos;
    private Slot slot;
    public Inventory inventory;
    public DragInstance dragInstance;
    public ItemManager canShoot;

    void Awake()  {
      slot = GetComponent<Slot>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
      if (transform.childCount > 0)  {
        dragInstance.itemDragging = this.transform.GetChild(0).gameObject;
      }
      dragInstance.slotDragging = GetComponent<Slot>();


    }

    public void OnPointerEnter(PointerEventData eventData)  {
      canShoot.enabled = false;
    }
    public void OnPointerExit(PointerEventData eventData)  {
      canShoot.enabled = true;
    }

    public void OnDrag(PointerEventData eventData) {

    }

    public void OnEndDrag(PointerEventData eventData) {


    }

    public void OnPointerDown(PointerEventData eventData) {

    }


}
