using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinUIManager : MonoBehaviour
{
    private TextMeshProUGUI coinAmountText;

    private void Start()
    {
        coinAmountText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameStateManager.Instance.coin == int.MaxValue)
            coinAmountText.SetText("\u221e");
        else 
            coinAmountText.SetText(GameStateManager.Instance.coin.ToString());
    }
}
