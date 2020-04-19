using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobDrop : MonoBehaviour
{
	public GameObject ARdropPrefab;
	public GameObject RPGdropPrefab;
	public GameObject SnipeDropPrefab;
	public GameObject HealthPrefab;
	public void SpiderDrop(Vector3 pos){
		float num = Random.Range(0,100);
        if(num <= 10){
            Instantiate(ARdropPrefab, pos, Quaternion.identity);
		}else if(num >= 80){
            Instantiate(HealthPrefab, pos, Quaternion.identity);
		}
	}
}
