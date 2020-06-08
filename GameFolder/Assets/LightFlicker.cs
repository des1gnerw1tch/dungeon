using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    [SerializeField] private Light2D light;
    [SerializeField] private float lowFrequency;
    [SerializeField] private float maxFrequency;
    [SerializeField] private float lowFlickerTime;
    [SerializeField] private float maxFlickerTime;

    private float counter;
    private float flickerTime;
    private bool isFlickering = false;

    void Start()  {
        counter = Random.Range(lowFrequency, maxFrequency);
        flickerTime = Random.Range(lowFlickerTime, maxFlickerTime);
    }

    void Update()
    {

      if (counter > flickerTime)  {
        counter -= Time.deltaTime;
      } else  {
        if (!isFlickering)  {
          Flicker();
          isFlickering = true;
        }
        if (counter <= 0f) {
          isFlickering = false;
          light.intensity = 1.5f;
          counter = Random.Range(lowFrequency, maxFrequency);
          flickerTime = Random.Range(lowFlickerTime, maxFlickerTime);
          //return;
        } else {
          counter -= Time.deltaTime;
        }
      }

    }

    void Flicker() {
      light.intensity = Random.Range(.5f, 1f);
    }
}
