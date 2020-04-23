using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobDrop : MonoBehaviour
{
	public GameObject ARdropPrefab;
	public GameObject RPGdropPrefab;
	public GameObject SnipeDropPrefab;
	public GameObject HealthPrefab;
	public GameObject CoinPrefab;
	Vector3 offset;
	public void SpiderDrop(Vector3 pos){
		float num = Random.Range(0,100);
        if(num <= 10){
            Instantiate(ARdropPrefab, pos, Quaternion.identity);
		}else if(num >= 70){
            Instantiate(HealthPrefab, pos, Quaternion.identity);
		}
	}
	public void GoblinDrop(Vector3 pos){
		Instantiate(CoinPrefab, pos, Quaternion.identity);
	}

	public void ChestDrop(Vector3 pos){
		
		offset.Set(pos.x + Random.Range(-3,3), pos.y + 2f, 0f);
		Instantiate(CoinPrefab, offset, Quaternion.identity);
		float num = Random.Range(0,100);
        if(num <= 10){
            Instantiate(ARdropPrefab, offset, Quaternion.identity);
		}else if(num <= 20 && num > 10){
            Instantiate(HealthPrefab, offset, Quaternion.identity);
		}else if(num <= 40 && num > 20){
			Instantiate(CoinPrefab, offset, Quaternion.identity);
		}else if(num <= 50 && num > 40){
			Instantiate(SnipeDropPrefab, offset, Quaternion.identity);
		}else if(num <= 55 && num > 50){
			Instantiate(RPGdropPrefab, offset, Quaternion.identity);
		}
	}
}
