using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] public string scene;
    private void Awake()
    {
        SceneManager.LoadScene(scene);
    }

    public static void Next(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
