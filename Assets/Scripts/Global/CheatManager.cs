using TMPro;
using UnityEngine;

public class CheatManager : MonoBehaviour
{
    private TextMeshProUGUI _cheatUIText;
    // Start is called before the first frame update
    private void Start()
    {
        _cheatUIText = GameObject.FindGameObjectWithTag("CheatUI").GetComponent<TextMeshProUGUI>();
        _cheatUIText.SetText("");
    }
}
