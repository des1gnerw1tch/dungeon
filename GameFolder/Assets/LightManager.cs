using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    [SerializeField]
    private GameObject basicLight;

    void Awake()
    {
      UpdateSceneLighting();
    }

    void UpdateSceneLighting()  {
      if (PlayerSettings.fancyGraphics) {
        basicLight.SetActive(false);
      } else {
        Light2D[] lights = FindObjectsOfType<Light2D>();
        foreach (Light2D light in lights) {
          light.gameObject.SetActive(false);
        }
        basicLight.SetActive(true);
      }
    }
}
