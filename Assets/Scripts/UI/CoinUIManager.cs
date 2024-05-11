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
        coinAmountText.SetText(GameStateManager.Instance.coin.ToString());
    }
}
