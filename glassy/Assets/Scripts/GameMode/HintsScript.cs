using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintsScript : MonoBehaviour
{
    public GameObject obj1,otherobj1,otherobj2,otherobj3,otherobj4,otherobj5;
    public void showHints(){
        if(obj1.activeSelf){
            obj1.SetActive(false);
        }
        else
        {
            obj1.SetActive(true);
            otherobj1.SetActive(false);
            otherobj2.SetActive(false);
            otherobj3.SetActive(false);
            otherobj4.SetActive(false);
            otherobj5.SetActive(false);
        }
    }
}
