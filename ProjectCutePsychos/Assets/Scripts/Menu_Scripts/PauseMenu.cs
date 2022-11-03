using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public static bool GameIsPausedShowingControls = false;

    public GameObject pauseMenuUI;
    public GameObject controlsMenuUI;

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
            else Pause(); //Pauses the game and shows pause menu
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GameIsPausedShowingControls)   //Resumes game if game is paused and you press tab
            {
                pauseMenuUI.SetActive(false); //disable pause menu if showing
                Time.timeScale = 1f;
                GameIsPausedShowingControls = false;
                controlsMenuUI.SetActive(false);
        

            }
            else //Pauses the game and show controls
            {
                pauseMenuUI.SetActive(false); // disable pause menu if showing
                Time.timeScale = 0f;
                GameIsPausedShowingControls = true;
                controlsMenuUI.SetActive(true);
            
            }
            
        
        }
    }

    public void Resume()
    {
        controlsMenuUI.SetActive(false); //Disable controls menu if showing
        pauseMenuUI.SetActive(false); //If game is not paused resume time
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() //Pauses the game and shows pause menu
    {
        controlsMenuUI.SetActive(false); //Disable controls menu if showing
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu() //Load Main Menu
    {
        SceneManager.LoadScene(0);
    }



}
