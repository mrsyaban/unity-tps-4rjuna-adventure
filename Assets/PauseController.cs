using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject hudMenuUI;
    public GameObject loadMenuUI;
    public TMP_InputField inputField;
    public Button saveButton;
    private string savedText;

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    public void Save()
    {
        savedText = inputField.text;
        SaveSystem.SaveGameState(savedText);
        SceneManager.LoadScene("GameMenuScene");
    } 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
            
        }
    }

    public void TogglePauseMenu()
    {
        pauseMenuUI.SetActive(true);
        hudMenuUI.SetActive(false);
        loadMenuUI.SetActive(false);
        Time.timeScale = 0f;
        Debug.Log("PAUSE");
        // Cursor.lockState = CursorLockMode.None;
        // Cursor.visible = true;
    }

    public void ToggleResume()
    {
        Debug.Log("RESUME");
        pauseMenuUI.SetActive(false);
        hudMenuUI.SetActive(true);
        Time.timeScale = 1.0f;
        // Cursor.lockState = CursorLockMode.Locked;
    }

    public void ToggleSaveMenu()
    {
        Debug.Log("SAVE");
        loadMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        SceneManager.LoadScene("GameMenuScene");
    }
}
