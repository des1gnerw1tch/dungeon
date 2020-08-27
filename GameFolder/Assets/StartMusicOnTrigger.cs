using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusicOnTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject musicPlayer;

    void OnTriggerEnter2D(Collider2D other) {
      if (other.CompareTag("Player")) {
        musicPlayer.SetActive(true);
      }
    }
}
