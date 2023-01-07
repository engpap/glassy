using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideContent : MonoBehaviour
{
    public GameObject[] objectsToHide;
    private bool hasBeenHidden=false;
    public void HideGameObjects(){
        foreach(GameObject obj in objectsToHide)
            obj.SetActive(hasBeenHidden);
        hasBeenHidden=!hasBeenHidden;
    }
}
