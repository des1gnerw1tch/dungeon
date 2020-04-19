using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    private int activeSlot = 0;
    private int lastSlot;
    public RectTransform indicatorLoc;
    public RectTransform slot0;
    public RectTransform slot1;
    public RectTransform slot2;
    public RectTransform slot3;
    public RectTransform slot4;
    private Shooting shootingScript;
    public Inventory inventory;
    private DestroyGun destroyGun;
    public Slot activeCanvasSlot;
    public Slot canvasSlot0;
    public Slot canvasSlot1;
    public Slot canvasSlot2;
    public Slot canvasSlot3;
    public Slot canvasSlot4;
    // Start is called before the first frame update
    void Start()
    {
      shootingScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>();
      destroyGun = GameObject.FindGameObjectWithTag("FirePoint").GetComponent<DestroyGun>();
      lastSlot = activeSlot;
    }

    // Update is called once per frame
    void Update()
    {
        //input logic
        if (Input.mouseScrollDelta.y >= .1)  {
          //scroll down, add
          if (activeSlot >= 4) {
            activeSlot = 0;
          } else {
            activeSlot++;
          }

        }
        else if (Input.mouseScrollDelta.y <= -.1)  {
          //scroll up, subtract
          if (activeSlot <= 0) {
            activeSlot = 4;
          } else {
            activeSlot--;
          }

        }
        //ui switches black dot and active slot
        switch (activeSlot) {
          case 0 :
            indicatorLoc.anchoredPosition = slot0.anchoredPosition;
            activeCanvasSlot = canvasSlot0;
            break;
          case 1:
            indicatorLoc.anchoredPosition = slot1.anchoredPosition;
            activeCanvasSlot = canvasSlot1;
            break;
          case 2:
            indicatorLoc.anchoredPosition = slot2.anchoredPosition;
            activeCanvasSlot = canvasSlot2;
            break;
          case 3:
            indicatorLoc.anchoredPosition = slot3.anchoredPosition;
            activeCanvasSlot = canvasSlot3;
            break;
          case 4:
            indicatorLoc.anchoredPosition = slot4.anchoredPosition;
            activeCanvasSlot = canvasSlot4;
            break;
        }


          //equips gun from bob shooting script
          shootingScript.whatGunIsEquippedString = inventory.item[activeSlot];

          //makes sure that gun dissapears
          if (lastSlot != activeSlot) {
            shootingScript.showGun = false;
            lastSlot = activeSlot;
          }
          //drop, janky
          if (Input.GetKeyDown("q") && inventory.item[activeSlot] != null)  {
            inventory.item[activeSlot] = null;
            shootingScript.showGun = false;
            //only drops the top item
            activeCanvasSlot.DropItem();
            //destroyGun.DropGun();
          }


    }
}
