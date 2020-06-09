using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentManager : MonoBehaviour
{
    public VaultHolder vaultHolder;
    void Start()
    {
      vaultHolder = FindObjectOfType<VaultHolder>();
      vaultHolder.EnableVault();
    }

}
