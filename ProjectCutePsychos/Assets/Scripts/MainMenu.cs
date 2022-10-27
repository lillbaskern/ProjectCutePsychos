using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }

    public void QuitGame()
    {
        if (Application.isEditor) // Ends play mode if in editor, if not, quits the game.
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        Application.Quit();

    }
}


