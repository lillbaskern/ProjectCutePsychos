using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController
{
    public static void Load(Scene scene){
        SceneManager.LoadScene(scene.ToString());
    }
    public static void LoadNext(){
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
    }
    //<Summary>
    //loads the current scene again. like loadnext but without the + 1
    public static void Reload(){
        var current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }

}
