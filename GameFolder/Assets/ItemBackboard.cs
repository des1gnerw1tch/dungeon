using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBackboard : MonoBehaviour
{
    public Image image;

    public Sprite commonBackboard;
    public Sprite rareBackboard;
    public Sprite specialBackboard;
    public Sprite majesticBackboard;
    public Text rarityText;

    public void UpdateImage(Gun gun) {

      if (gun != null) {
        switch(gun.rarity)  {
          case "Rare":
            image.sprite = rareBackboard;
            rarityText.text = gun.rarity;
            break;
          case "Special":
            image.sprite = specialBackboard;
            rarityText.text = gun.rarity;
            break;
          case "Majestic":
            image.sprite = majesticBackboard;
            rarityText.text = gun.rarity;
            break;
          default:
            image.sprite = commonBackboard;
            rarityText.text = "Common";
            break;

        }
    } else {
      image.sprite = commonBackboard;
      rarityText.text = null;
    }

    }

    public void ShowItemBackboard(Item item)  {
      image.sprite = commonBackboard;
      rarityText.text = item.type;
    }
}
