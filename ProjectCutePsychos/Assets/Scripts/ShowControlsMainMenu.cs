using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowControlsMainMenu : MonoBehaviour
{
    public GameObject Controls;
    public GameObject Mainmenu;
    public GameObject Backbutton;
    
    [SerializeField] private string _sceneNameToLoad;

   public void ShowControls()
   {
    Mainmenu.SetActive(false);
    Controls.SetActive(true);
    Backbutton.SetActive(true);
   }

   public void ShowMainmenu()
   {
    Controls.SetActive(false);
    Mainmenu.SetActive(true);
    Backbutton.SetActive(false);
   }

   public void ShowCredits()
   {
    SceneManager.LoadScene(_sceneNameToLoad);
    
   }

}
