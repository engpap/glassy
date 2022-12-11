using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDrop : MonoBehaviour
{
    #region Attributes

    public GameObject BrainCard;
    public GameObject LungsCard;


    #endregion

    #region MonoBehaviour API

    public void Start(){
        BrainCard.SetActive(false);
        LungsCard.SetActive(false);
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag=="Brain")
            ShowInfoCard("Brain");
        if(other.tag=="Lungs")
            ShowInfoCard("Lungs");
    }

    private void OnTriggerExit(Collider other){
        if(other.tag=="Brain")
            HideInfoCard("Brain");
        if(other.tag=="Lungs")
            HideInfoCard("Lungs");
    }
    #endregion

    public void HideInfoCard(string tagName){
        if(tagName=="Brain"){
            BrainCard.SetActive(false);
        }
        if(tagName=="Lungs"){
            LungsCard.SetActive(false);
        }  
    }

    public void ShowInfoCard(string tagName){
        if(tagName=="Brain"){
            BrainCard.SetActive(true);
        }
        if(tagName=="Lungs"){
            LungsCard.SetActive(true);
        }
    }

}
