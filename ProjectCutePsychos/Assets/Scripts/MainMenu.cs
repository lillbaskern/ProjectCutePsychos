using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("HugoBossTest"); //Loads scene when called by event


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


