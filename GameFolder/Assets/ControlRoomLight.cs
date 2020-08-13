using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRoomLight : MonoBehaviour
{
    [SerializeField] private AlarmTrigger alarmTrigger;
    // Start is called before the first frame update
    void Start()
    {
      if (LavaDungManager.powerOn)  {
        alarmTrigger.triggerWarningLight();
      }
    }

}
