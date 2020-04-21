using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

  public CinemachineVirtualCamera vcam;

  public float mainOrthographicView;
  public float caveOrthographicView;


    void Update()
    {
      Scene scene = SceneManager.GetActiveScene();

      switch (scene.name) {
        case "Main":
          vcam.m_Lens.OrthographicSize = mainOrthographicView;
          break;
        case "Cave":
          vcam.m_Lens.OrthographicSize = caveOrthographicView;
          break;
      }

    }
}
