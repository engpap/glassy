using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

  public void PlayGame(){
    SceneManager.LoadScene(1);
    Debug.Log(">>> Play Scene loaded!");
  }
  public void ExploreGame(){
    SceneManager.LoadScene(2);
    Debug.Log(">>> Explore Scene loaded!");
  }

  public void BacktoMenu(){
    SceneManager.LoadScene(0);
    Debug.Log(">>> Home Menu Scene loaded!");
  }
}
