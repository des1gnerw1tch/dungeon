using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentManager : MonoBehaviour
{
    public VaultHolder vaultHolder;
    public GameObject friendNPC;
    void Start()
    {
      vaultHolder = FindObjectOfType<VaultHolder>();
      vaultHolder.EnableVault();
      if (PlayerProgress.friendFreed) {
        friendNPC.SetActive(true);
      } else {
        friendNPC.SetActive(false);
      }
    }

}
