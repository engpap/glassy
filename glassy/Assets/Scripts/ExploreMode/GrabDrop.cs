using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDrop : MonoBehaviour
{
    #region Attributes

    public GameObject BrainCard;


    #endregion

    #region MonoBehaviour API

    public void Start(){
        BrainCard.SetActive(false);
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag=="Brain")
            ShowInfoCard("Brain");
    }

    private void OnTriggerExit(Collider other){
        if(other.tag=="Brain")
            HideInfoCard("Brain");
    }
    #endregion

    public void HideInfoCard(string tagName){
        if(tagName=="Brain"){
            BrainCard.SetActive(false);
        } 
    }

    public void ShowInfoCard(string tagName){
        if(tagName=="Brain"){
            BrainCard.SetActive(true);
        }
    }

}
