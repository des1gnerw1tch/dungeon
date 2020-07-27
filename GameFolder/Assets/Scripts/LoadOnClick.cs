using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadOnClick : MonoBehaviour
{

    [SerializeField]
    private MenuManager menuManager;
    [SerializeField]
    private float delay;


    public void Click()  {
      menuManager.PlaySave(delay);
    }


}
