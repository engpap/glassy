using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
  public void PlayGame(){
    SceneManager.LoadScene(2);
  }
  public void ExploreGame(){
    SceneManager.LoadScene(3);
  }
}
