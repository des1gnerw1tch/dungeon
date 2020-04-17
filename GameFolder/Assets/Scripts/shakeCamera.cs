using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakeCamera : MonoBehaviour
{

    private float ShakeDuration;
    private float ShakeAmplitude;
    private float ShakeFrequency;

    private float ShakeElapsedTime = 0f;

    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    // Start is called before the first frame update
    void Start()
    {
      /*this gets my virtual camera, and cets its "noise" compenent to a variable
      (noise is shake) */
      if(VirtualCamera != null) {
        virtualCameraNoise = VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
      }

    }

    // Update is called once per frame
    void Update()
    {

      if (VirtualCamera != null || virtualCameraNoise != null)  {

        if (ShakeElapsedTime > 0) {
          virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude;
          ShakeElapsedTime -= Time.deltaTime;
            //Debug.Log(ShakeElapsedTime);
        }  else {
          virtualCameraNoise.m_AmplitudeGain = 0f;
          ShakeElapsedTime = 0f;
        }
      }

  }


  /*this function is called by another function, and will shake the camera
  to a desired amplitude, frequency, and duration */
    public void shake(float amplitude, float frequency, float duration) {

      ShakeAmplitude = amplitude;
      ShakeFrequency = frequency;
      ShakeElapsedTime = duration;
    }
}
