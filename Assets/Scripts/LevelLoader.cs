using System.Collections;
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

    }

    public void NextLevel()
    {
        
        SceneManager.LoadScene(nextSceneIndex);
        
       
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

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "Teleport")
        {
            NextLevel();
        }
    }
}
