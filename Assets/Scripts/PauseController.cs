using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour {

    public GameObject pauseMenu;

    void Start ()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Pause"))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                Cursor.visible = true;
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                Cursor.visible = false;
                pauseMenu.SetActive(false);
                
            }
        }
    }

    public void PauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            Cursor.visible = true;
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            Cursor.visible = false;
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
