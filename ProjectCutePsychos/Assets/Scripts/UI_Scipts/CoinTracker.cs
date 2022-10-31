using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTracker : MonoBehaviour
{
    public static CoinTracker instance;

    public TMP_Text coinText;
    public int currentCoins = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        coinText.text = "COINS: " + currentCoins.ToString();
    }

    public void IncreaseCoins(int coins)
    {
        currentCoins += coins;
        coinText.text = "COINS: "+ currentCoins.ToString();
    }

}
