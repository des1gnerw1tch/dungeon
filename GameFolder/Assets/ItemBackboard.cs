using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBackboard : MonoBehaviour
{
    public Image image;

    public Sprite commonBackboard;
    public Sprite rareBackboard;

    public void UpdateImage(Gun gun) {

      if (gun != null) {
        switch(gun.rarity)  {
          case "Rare":
            image.sprite = rareBackboard;
            break;
          default:
            image.sprite = commonBackboard;
            break;

        }
    } else {
      image.sprite = commonBackboard;
    }

    }
}
