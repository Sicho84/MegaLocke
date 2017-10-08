using UnityEngine;
using System.Collections;

//written by Sacha Galgon 2015

//this script manages when certain menus should be displayed 

public class PauseMenu : MonoBehaviour
{


    public GameObject pauseMenu; // Assign in inspector
    private bool isShowing = false;


    void Start()
    {

        pauseMenu.SetActive(false);
        Cursor.visible = false; //hides the mouse cursor
        Time.timeScale = 1f;
    }

    void Update()
    {

        if (Input.GetKeyDown("escape") || Input.GetKeyDown("joystick button 7"))
        {
            if (Time.timeScale != 0.0f)
            {
                Time.timeScale = 0.0f; //pauses the game
                isShowing = !isShowing;
                pauseMenu.SetActive(isShowing);
                Cursor.visible = true; //shows the mouse cursor
                Debug.Log(Time.timeScale);
            }

            else
            {
                Time.timeScale = 1.0f; //unpauses
                pauseMenu.SetActive(isShowing);
                Cursor.visible = false; //hides the mouse cursor
                Debug.Log(Time.timeScale);
            }
        }
    }
}
