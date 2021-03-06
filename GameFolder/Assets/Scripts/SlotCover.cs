﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class SlotCover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    /* this slot cover script will make it so that you cannot shoot or use items when hovering over it.
    this allows you to drag and drop items without shooting in between*/

    [SerializeField]
    private ItemManager canShoot;
    public void OnPointerEnter(PointerEventData eventData)  {
      canShoot.useDisabled = true;
    }
    public void OnPointerExit(PointerEventData eventData)  {
      //if vault is not activated, let them shoot
      if (!vault.vaultActivated)
        canShoot.useDisabled = false;
    }
}
