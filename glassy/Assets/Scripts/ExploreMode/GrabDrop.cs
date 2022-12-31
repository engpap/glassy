using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDrop : MonoBehaviour
{
    #region Attributes

    public GameObject Card_0;
    public GameObject Card_1;


    #endregion

    #region MonoBehaviour API

    public void Start(){
        Card_0.SetActive(false);
        Card_1.SetActive(false);
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag=="ModelOfCard_0")
            ShowInfoCard("Card_0");
        if(other.tag=="ModelOfCard_1")
            ShowInfoCard("Card_1");
    }

    private void OnTriggerExit(Collider other){
        if(other.tag=="ModelOfCard_0")
            HideInfoCard("Card_0");
        if(other.tag=="ModelOfCard_1")
            HideInfoCard("Card_1");
    }
    #endregion

    public void HideInfoCard(string tagName){
        if(tagName=="Card_0"){
            Card_0.SetActive(false);
        }  
        if(tagName=="Card_1"){
            Card_1.SetActive(false);
        }
    }

    public void ShowInfoCard(string tagName){
        if(tagName=="Card_0"){
            Card_0.SetActive(true);
        }
        if(tagName=="Card_1"){
            Card_1.SetActive(true);
        }
    }

}
