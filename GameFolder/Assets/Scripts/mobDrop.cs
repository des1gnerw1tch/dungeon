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
	public GameObject torch;
	private Vector2 force;
	private PlayerMoney PlayerMoneyScript;

	/*--------------Mob Drops-------------*/
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

	public void SlimeDrop(Vector3 pos)	{
		float num = Random.Range(0,100);
		if (num >= 0 && num <= 50)	{
			Instantiate(CoinPrefab, pos, Quaternion.identity);
		}
		else if (num > 50 && num <= 90)	{
			Instantiate(CoinPrefab, pos, Quaternion.identity);
			Instantiate(CoinPrefab, pos, Quaternion.identity);
		}
		else if (num > 90 && num <= 100)	{
			Instantiate(CoinPrefab, pos, Quaternion.identity);
			Instantiate(CoinPrefab, pos, Quaternion.identity);
			Instantiate(CoinPrefab, pos, Quaternion.identity);
		}
	}

	/*----------Chest Drops---------------*/
	public void ChestDrop(Vector3 pos){
		GameObject obj = null;
		Rigidbody2D objRB;

		//initial coins
		float numCoins = Random.Range(2,6);
		for (int i = 0; i < numCoins; i++ )	{
			obj = Instantiate(CoinPrefab, pos, Quaternion.identity);
			objRB = obj.GetComponent<Rigidbody2D>();
			force.Set(Random.Range(-3, 3), Random.Range(-3, 3));
			objRB.AddForce(force, ForceMode2D.Impulse);
		}

		//other drops
		float num = Random.Range(0,100);
        if(num <= 10){
            obj = Instantiate(ARdropPrefab, pos, Quaternion.identity);

		}else if(num <= 20 && num > 10){
            obj = Instantiate(HealthPrefab, pos, Quaternion.identity);
		}else if(num <= 40 && num > 20){
			obj = Instantiate(CoinPrefab, pos, Quaternion.identity);
		}else if(num <= 50 && num > 40){
			obj = Instantiate(SnipeDropPrefab, pos, Quaternion.identity);
		}else if(num <= 55 && num > 50){
			obj = Instantiate(RPGdropPrefab, pos, Quaternion.identity);
		}

		//getting second drop !!!
		objRB = obj.GetComponent<Rigidbody2D>();
		force.Set(Random.Range(-10, 10), Random.Range(-10, 10));
		objRB.AddForce(force, ForceMode2D.Impulse);

	}

	/*--------------Shop Drops------------*/
	public void ShopDrop(string ID, int cost,Vector3 pos){
		GameObject obj;
		Rigidbody2D objRB;
		PlayerMoneyScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoney>();

		if(ID == "AR" && PlayerMoneyScript.coins >= cost){
			obj = Instantiate(ARdropPrefab, pos, Quaternion.identity);
			PlayerMoneyScript.coins -= cost;
			objRB = obj.GetComponent<Rigidbody2D>();
			force.Set(Random.Range(-10, 10), Random.Range(2, 4));
			objRB.AddForce(force, ForceMode2D.Impulse);


		}
		else if(ID == "RPG" && PlayerMoneyScript.coins >= cost){
			obj = Instantiate(RPGdropPrefab, pos, Quaternion.identity);
			PlayerMoneyScript.coins -= cost;

			objRB = obj.GetComponent<Rigidbody2D>();
			force.Set(Random.Range(-10, 10), Random.Range(2, 4));
			objRB.AddForce(force, ForceMode2D.Impulse);


		}
		else if(ID == "Sniper" && PlayerMoneyScript.coins >= cost){
			obj = Instantiate(SnipeDropPrefab, pos, Quaternion.identity);
			PlayerMoneyScript.coins -= cost;

			objRB = obj.GetComponent<Rigidbody2D>();
			force.Set(Random.Range(-10, 10), Random.Range(2, 4));
			objRB.AddForce(force, ForceMode2D.Impulse);


		}
		else if(ID == "HealthPotion" && PlayerMoneyScript.coins >= cost){
			obj = Instantiate(HealthPrefab, pos, Quaternion.identity);
			PlayerMoneyScript.coins -= cost;

			objRB = obj.GetComponent<Rigidbody2D>();
			force.Set(Random.Range(-10, 10), Random.Range(2, 4));
			objRB.AddForce(force, ForceMode2D.Impulse);


		}

	}

}
