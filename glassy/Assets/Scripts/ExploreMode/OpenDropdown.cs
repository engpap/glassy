using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OpenDropdown : MonoBehaviour
{
    public Button OriginButton;
    public GameObject OriginCard;
    public Button FloweringButton;
    public GameObject FloweringCard;
    public Button EtimologyButton;
    public GameObject EtimologyCard;

    // Start is called before the first frame update
    void Start()
    {
        OriginCard.SetActive(false);
        EtimologyCard.SetActive(false);
        FloweringCard.SetActive(false);
        OriginButton.onClick.AddListener(delegate{OpenDropdownOnClick("Origin");}); 
        FloweringButton.onClick.AddListener(delegate{OpenDropdownOnClick("Flowering");});   
        EtimologyButton.onClick.AddListener(delegate{OpenDropdownOnClick("Etimology");}); 
    }

    void OpenDropdownOnClick(string buttonName){
        if(buttonName=="Origin"){
            handleDropdown(OriginCard);
            Console.WriteLine("Origin button is selected");
        }
        if(buttonName=="Flowering"){
            handleDropdown(FloweringCard);
            Console.WriteLine("Flowering button is selected");
        }
        if(buttonName=="Etimology"){
            handleDropdown(EtimologyCard);
            Console.WriteLine("Etimology button is selected");
        }

    }

    void handleDropdown(GameObject dropdown){
        if(dropdown.activeSelf)
            dropdown.SetActive(false);
        else
            dropdown.SetActive(true);
    }



}
