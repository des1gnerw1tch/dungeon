using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMoney : MonoBehaviour
{
    public int coins = 0;
    public Text CoinCountText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinCountText.text = "" + coins;
    }
}
