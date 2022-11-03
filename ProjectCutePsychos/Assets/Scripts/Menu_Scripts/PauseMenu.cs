using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private void Start() {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)   //Resumes game if game is paused and you press escape
            {
                Resume();

            }
            else Pause(); //Pauses the game
        }
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false); //If game is not paused resume time
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true); //If game is paused freeze time
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu() //Load Main Menu
    {
        SceneManager.LoadScene(0);
    }

}
