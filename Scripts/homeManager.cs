using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class homeManager : MonoBehaviour
{
    
   public void StartSchene()
    {
        SceneManager.LoadScene(1);
    }
  public  void exit()
    {
        Application.Quit();
    }
}
