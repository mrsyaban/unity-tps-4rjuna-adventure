using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject statisticsCanvas;
    public GameObject loadCanvas;
    public GameObject settingsCanvas;

    //Settings UI Field
    public TMP_InputField playerNameInput;
    public Slider volumeSlider;
    public TMP_Text volumeValueInfo;

    private void Awake()
    {
        GameStateManager.Instance.LoadGameState();
    }

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
        NextScene.Next("Scenes/Cutscene01");
        //GameStateManager.Instance = null
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
        playerNameInput.text = GameStateManager.Instance.playerName;
        volumeSlider.value = GameStateManager.Instance.gameVolume;
        volumeValueInfo.text = ((int)GameStateManager.Instance.gameVolume).ToString() + "%";
    }

    public void CloseSettings()
    {
        settingsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
        statisticsCanvas.SetActive(false);
        loadCanvas.SetActive(false);
        GameStateManager.Instance.playerName = playerNameInput.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSliderChanged()
    {
        GameStateManager.Instance.gameVolume = volumeSlider.value;
        AudioListener.volume = volumeSlider.value / 100;
        volumeValueInfo.text = ((int)volumeSlider.value).ToString() + "%";
    }
}
