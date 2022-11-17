using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintsScript : MonoBehaviour
{
    public GameObject obj1;
    public void showHints(){
        if(obj1.activeSelf){
            obj1.SetActive(false);
            Debug.Log("disattivato");
        }
        else
        {
            obj1.SetActive(true);
            Debug.Log("attivato");
        }
    }
}
