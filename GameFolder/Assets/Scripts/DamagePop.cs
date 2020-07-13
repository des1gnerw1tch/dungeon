using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePop : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshPro tmp;

    public void SetDamage(int damage) {
      tmp.text = damage + "";
    }
}
