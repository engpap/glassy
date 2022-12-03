using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDrop : MonoBehaviour
{
    #region Attributes

    public GameObject HeartCard;

    #endregion

    #region MonoBehaviour API

    public void Start(){
        HeartCard.SetActive(false);
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag=="Heart")
            ShowInfoCard("Heart");
    }

    private void OnTriggerExit(Collider other){
        if(other.tag=="Heart")
            HideInfoCard("Heart");
    }
    #endregion

    public void HideInfoCard(string tagName){
        if(tagName=="Heart"){
            HeartCard.SetActive(false);
        } 
    }

    public void ShowInfoCard(string tagName){
        if(tagName=="Heart"){
            HeartCard.SetActive(true);
        }
    }

}
