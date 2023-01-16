using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu:MonoBehaviour
{
    
  public void Play()
  {
    SceneManager.LoadScene("Level1Scene");
  }

  public void Quit()
 {
    Application.Quit();
    Debug.Log("Quit");
    
 }
    

    
}
