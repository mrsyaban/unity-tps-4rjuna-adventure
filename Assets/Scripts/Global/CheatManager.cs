using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheatManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cheatUIText;
    private string curInput = "";
    private CheatCodeBase[] cheatCodes;
    private Coroutine resetInputCoroutine;
    
    private void Start()
    {
        cheatUIText.SetText("");
        cheatCodes = new CheatCodeBase[8];
        cheatCodes[0] = new CheatCodeNoDamage();
        cheatCodes[1] = new CheatCodeOneHit();
        cheatCodes[2] = new CheatCodeMotherlode();
        cheatCodes[3] = new CheatCodeTwiceSpeed();
        cheatCodes[4] = new CheatCodeFullPetHP();
        cheatCodes[5] = new CheatCodeKillPet();
        cheatCodes[6] = new CheatCodeOrb();
        cheatCodes[7] = new CheatCodeSkip();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (resetInputCoroutine != null)
                StopCoroutine(resetInputCoroutine);
            resetInputCoroutine = StartCoroutine(ResetInputAfterDelay());
        }
        
        foreach (CheatCodeBase cheat in cheatCodes)
        {
            if (cheat.Code == curInput)
            {
                cheat.RunCheat();
                cheatUIText.SetText(cheat.Desc + " activated");
                StartCoroutine(ResetCheatText());
                curInput = ""; // Reset input
                return;
            }
        }
        curInput += Input.inputString;
    }
    
    private IEnumerator ResetInputAfterDelay()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        curInput = ""; // Reset the input
    }
    
    private IEnumerator ResetCheatText()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        cheatUIText.SetText(""); // Reset the cheat text
    }
}
