using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTracker : MonoBehaviour
{
    public static CoinTracker Instance;

    public TMP_Text coinText;
    public int currentCoins = 0;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        coinText.text = "X: " + currentCoins.ToString();
    }
    public void IncreaseCoins(int coins)
    {
        currentCoins += coins;
        coinText.text = "X: "+ currentCoins.ToString();
    }

}
