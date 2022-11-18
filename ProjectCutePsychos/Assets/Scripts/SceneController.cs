using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/* Elias. F.
SUMMARY:
A static class meant to handle progression between scenes.
*/
public static class SceneController
{
    //<Summary>
    //Sets an int to the currently active scene's build index PLUS one (+1) and loads the scene with that index number 
    public static void LoadNext(){
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
    //<Summary>
    //loads the current scene again by getting the current scene's build index and loading that
    //getting the int of the currently active scene's build index did not work during development, which is why i get a reference to the scene instead 
    public static void Reload(){
        var current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }


}
