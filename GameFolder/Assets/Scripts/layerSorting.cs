using UnityEngine;

public class layerSorting : MonoBehaviour
{
  public Transform player;
  public SpriteRenderer tree;

    // Update is called once per frame
    void Update()
    {
      if (player.position.y > transform.position.y - .8) {

        tree.sortingOrder = 4;
      } else  {

        tree.sortingOrder = 1;
      }

    }
}
