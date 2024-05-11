using TMPro;
using UnityEngine;

public class Objective03 : Objective
{
    [SerializeField] public TextMeshProUGUI KrocoUI;
    [SerializeField] public TextMeshProUGUI KepalaKrocoUI;
    [SerializeField] public TextMeshProUGUI JendralUI;
    [SerializeField] public Transform player;
    [SerializeField] public GameObject altar;

    private int curKrocoKilled = GameStateManager.Instance.krocoKill;
    private int curKepalaKrocoKilled = GameStateManager.Instance.kepalaKrocoKill;
    private int curJendralKilled = GameStateManager.Instance.jendralKill;
    
    public override bool IsCompleted()
    {
        int krocoTreshold = 1;
        int kepalaKrocoTreshold = 0;
        int jendralTreshold = 0;
        
        int krocoKilled = GameStateManager.Instance.krocoKill - curKrocoKilled;
        KrocoUI.SetText("Kroco: " +krocoKilled.ToString()+"/"+krocoTreshold);
        
        int kepalaKrocoKilled = GameStateManager.Instance.kepalaKrocoKill - curKepalaKrocoKilled;
        KepalaKrocoUI.SetText("Kepala Kroco: "+kepalaKrocoKilled.ToString()+"/"+kepalaKrocoTreshold);
        
        int jendralKilled = GameStateManager.Instance.jendralKill - curJendralKilled;
        JendralUI.SetText("Jendral: "+krocoKilled.ToString()+"/"+jendralTreshold);

        if (krocoKilled >= krocoTreshold && kepalaKrocoKilled >= kepalaKrocoTreshold && jendralKilled >= jendralTreshold)
        {
            altar.SetActive(true);
            float playerDistance = Vector3.Distance(altar.transform.position, player.position);
            if (playerDistance < 5f)
            {
                return true;
            }
        }
        else
        {
            altar.SetActive(false);
        }
        return false;
    }
}
