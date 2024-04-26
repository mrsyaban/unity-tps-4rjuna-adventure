using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Load Scene sesuai namanya, perlu dibuat lebih modular nanti kayanya
        SceneManager.LoadScene("Scene_X");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

