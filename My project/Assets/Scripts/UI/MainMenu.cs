using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void LaunchGame(int level)
   {
       SceneManager.LoadScene(level);
   }
   
   public void QuitGame()
   {
       Application.Quit();
   }
}
