using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePop : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshPro tmp;
    [SerializeField]
    private Color critHitColor;

    public void SetDamage(int damage, bool critical) {
      tmp.text = damage + "";
      if (critical) {
        tmp.color = critHitColor;
        Debug.Log("Test");
      }
    }
}
