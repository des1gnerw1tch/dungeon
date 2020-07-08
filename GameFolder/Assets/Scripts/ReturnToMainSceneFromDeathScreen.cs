using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainSceneFromDeathScreen : MonoBehaviour
{
	public void MainScene(){
		SceneManager.LoadScene("Main");
	}
}
