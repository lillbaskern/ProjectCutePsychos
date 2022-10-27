using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController
{
    //these enums should be very specific in how they want you to name things, so maybe just an array or list of strings would be the same in functionality but less complex
    [SerializeField]public enum Scene{
        MainMenu
    }
    public static void Load(Scene scene){
        SceneManager.LoadScene(scene.ToString());
    }
    public static void LoadNext(){
        var current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex + 1);
    }
    //<Summary>
    //loads the current scene again. like loadnext but without the + 1
    public static void Reload(){
        var current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }

}
