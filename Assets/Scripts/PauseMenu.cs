using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

//written by Sacha Galgon 2017

//this script manages when the pause menu should be displayed 

public class PauseMenu : MonoBehaviour
{

    public EventSystem eventSystem; //assign the eventsystem of the scene to this in the inspector, see comments in coroutine highlightBtn
    public GameObject pauseMenu; // assign in inspector
    

    void Start()
    {

        pauseMenu.SetActive(false); //init the pauseMenu as inactive

        Cursor.visible = false; //hides the mouse cursor
        Time.timeScale = 1f;
    }

    void Update()
    {
        
            if (Input.GetKeyDown("escape") || Input.GetKeyDown("joystick button 7"))
            {
                if (Time.timeScale > 0.0f)
                {
                    PauseGame();
                }

                else
                {
                    UnPauseGame();
                }
            }
        
    }

    public void PauseGame()
    {
        StartCoroutine("highlightBtn"); //see comments in the coroutine
        Time.timeScale = 0.0f; //pauses the game
        pauseMenu.SetActive(true);
        Cursor.visible = true; //shows the mouse cursor
        Debug.Log(Time.timeScale);
        
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1.0f; //unpauses
        pauseMenu.SetActive(false);
        Cursor.visible = false; //hides the mouse cursor
        Debug.Log(Time.timeScale);
        
    }

    
    IEnumerator highlightBtn()
    {
        //even though the first button in the Pause Menu is set as Selected in the EventSystem
        //somehow Unity does not highlight that button, which we need for gamepad/keyboard controls and UI intuitivity
        //this coroutine fixes this

        eventSystem.SetSelectedGameObject(null);
        yield return null;
        eventSystem.SetSelectedGameObject(eventSystem.firstSelectedGameObject);
    }
}
