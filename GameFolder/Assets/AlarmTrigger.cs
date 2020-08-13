using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
  [SerializeField]
  private GameObject normalLight;
  [SerializeField]
  private GameObject warningLight;
    void OnTriggerEnter2D(Collider2D other) {
      if (other.CompareTag("Player")) {
        triggerWarningLight();
      }
    }

    public void triggerWarningLight() {
      warningLight.SetActive(true);
      normalLight.SetActive(false);
    }
}
