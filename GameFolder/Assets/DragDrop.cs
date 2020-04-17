using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragDrop : MonoBehaviour,IPointerDownHandler,IBeginDragHandler, IEndDragHandler{

	 public void OnBeginDrag(PointerEventData eventData){
		Debug.Log("1");
	 }
	 public void OnEndDrag(PointerEventData eventData){
		Debug.Log("2");
	 }
	 public void OnPointerDown(PointerEventData eventData){
		Debug.Log("3");
	 }
}
