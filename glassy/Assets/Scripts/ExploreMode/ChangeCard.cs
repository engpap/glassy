using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ChangeCard : MonoBehaviour
{
    // Details Section
    public Button DetailsButton;
    private bool hasDetailsButtonClicked = false;
    public GameObject DetailsPanel;
    public Button OriginButton;
    public Button FloweringButton;
    public Button EtimologyButton;

    // Evolution Section
    public Button EvolutionButton;
    private bool hasEvolutionButtonClicked = false;
    //public GameObject BirthPlantModel;
    //public GameObject MiddleAgePlantModel;

    //public GameObject LateAgePlantModel;


    // Health Section
    public Button HealthButton;
    private bool hasHealthButtonClicked = false;
    // TODO: similar to Evolution

    

    // Start is called before the first frame update
    void Start()
    {   
        // Hide buttons that should be activated when Details button is clicked
        setActive_DetailsFunctionality(false);

        // Hide 3D models that should be activated when Evolution button is clicked
        setActive_EvolutionFunctionality(false);


        //---- Add Buttons Listeners
        DetailsButton.onClick.AddListener(delegate{ChangeImage("Details");}); 
        EvolutionButton.onClick.AddListener(delegate{ChangeImage("Evolution");});   
        HealthButton.onClick.AddListener(delegate{ChangeImage("Health");}); 
        //----------------------------------------------------------------
    }

    void ChangeImage(string buttonName){
        
        if(buttonName=="Details"){
            Console.WriteLine("Details button is selected");
            hasDetailsButtonClicked=!hasDetailsButtonClicked;
            setActive_DetailsFunctionality(hasDetailsButtonClicked);
            setActive_EvolutionFunctionality(false);
            setActive_HealthFunctionality(false);
            
        }
        if(buttonName=="Evolution"){
            Console.WriteLine("Evolution button is selected");
            hasEvolutionButtonClicked=!hasEvolutionButtonClicked;
            setActive_EvolutionFunctionality(hasEvolutionButtonClicked);
            setActive_DetailsFunctionality(false);
            setActive_HealthFunctionality(false);
            //TODO: similar to Evolution

        }
        if(buttonName=="Health"){
            Console.WriteLine("Health button is selected");
            hasHealthButtonClicked=!hasHealthButtonClicked;
            setActive_HealthFunctionality(hasHealthButtonClicked);
            setActive_EvolutionFunctionality(false);
            setActive_DetailsFunctionality(false);
            //TODO: similar to Evolutionx
        }
    }


    /**
    *   Hide buttons that should be activated when Details button is clicked
    */
    private void setActive_DetailsFunctionality(bool state){
        hasDetailsButtonClicked=state;
        DetailsPanel.SetActive(state);
        OriginButton.gameObject.SetActive(state);
        FloweringButton.gameObject.SetActive(state);
        EtimologyButton.gameObject.SetActive(state);
    }

    /**
    *   Hide buttons that should be activated when Evolution button is clicked
    */
    private void setActive_EvolutionFunctionality(bool state){
        hasEvolutionButtonClicked=state;
        //BirthPlantModel.gameObject.SetActive(state);
        //MiddleAgePlantModel.gameObject.SetActive(state);
        //LateAgePlantModel.gameObject.SetActive(state);
    }


    /**
    *   Hide buttons that should be activated when Health button is clicked
    */
    private void setActive_HealthFunctionality(bool state){
        hasHealthButtonClicked=state;
        //TODO: similar to Evolution
    }







}
