using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject statisticsCanvas;
    public GameObject loadCanvas;
    public GameObject settingsCanvas;

    // Start is called before the first frame update
    private void Start()
    {
        mainMenuCanvas.SetActive(true);
        loadCanvas.SetActive(false);
        statisticsCanvas.SetActive(false);
        loadCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level01");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
		Application.Quit();
        #endif
    }

    public void OpenLoadSavedGame()
    {
        mainMenuCanvas.SetActive(false);
        loadCanvas.SetActive(true);
        statisticsCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
    }

    public void CloseLoadSavedGame()
    {
        mainMenuCanvas.SetActive(true);
        loadCanvas.SetActive(false);
        statisticsCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
    }

    public void OpenGameStatistics()
    {
        mainMenuCanvas.SetActive(false);
        statisticsCanvas.SetActive(true);
        loadCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
    }

    public void CloseGameStatistics()
    {
        mainMenuCanvas.SetActive(true);
        statisticsCanvas.SetActive(false);
        loadCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
        statisticsCanvas.SetActive(false);
        loadCanvas.SetActive(false);
    }

    public void CloseSettings()
    {
        settingsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
        statisticsCanvas.SetActive(false);
        loadCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
