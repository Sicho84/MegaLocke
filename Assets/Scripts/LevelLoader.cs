﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour {

    private int currentSceneIndex;
    private int nextSceneIndex;
    private int previousSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex = currentSceneIndex + 1;
        if (currentSceneIndex > 0)
       {
            previousSceneIndex = currentSceneIndex - 1;
       }

        string nextSceneString = nextSceneIndex.ToString();
        string currentSceneString = currentSceneIndex.ToString();
        Debug.Log(currentSceneIndex);
        Debug.Log(nextSceneIndex);
        Debug.Log("Next Scene Index " + nextSceneString);
        Debug.Log("Current Scene Index " + currentSceneString);

    }

    public void NextLevel()
    {
        string  sceneString = nextSceneIndex.ToString();
        SceneManager.LoadScene(nextSceneIndex);
        Debug.Log("Next Scene Index " + sceneString);
    }

   public void PreviousLevel()
    {
        SceneManager.LoadScene(previousSceneIndex);
    }

   public void LeaveGame()
    {
        Application.Quit();

    }

   public void LoadStartLevel()
    {
        SceneManager.LoadScene("Level0");
    }

    public void LoadHowtoPlay()
    {
        SceneManager.LoadScene("HowtoPlay");
    }
}
