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
    public  Button EvolutionButton;
    private bool hasEvolutionButtonClicked = false;

    public GameObject Model_1;
    public GameObject Model_2;

    //public GameObject Animation3D;


    // Health Section
    public Button HealthButton;
    private bool hasHealthButtonClicked = false;
    // TODO: similar to Evolution

    // Common button for Evolution and Health sections
    public Button ResetItemsButton; // Reset the position of 3D objects

    

    // Start is called before the first frame update
    void Start()
    {   
        // Hide buttons that should be activated when Details button is clicked
        setActive_DetailsFunctionality(false);

        // Hide 3D models that should be activated when Evolution button is clicked
        setActive_EvolutionFunctionality(false);


        // Hide 3D models that should be activated when Health button is clicked
        setActive_HealthFunctionality(false);


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
        Model_1.gameObject.SetActive(state);
        Model_2.gameObject.SetActive(state);
        //Animation3D.gameObject.SetActive(state);
        ResetItemsButton.gameObject.SetActive(state); //TO FIX BECAUSE IF U PUT IT ALSO IN HEALTH IT DOES NOT WORK
    }


    /**
    *   Hide buttons that should be activated when Health button is clicked
    */
    private void setActive_HealthFunctionality(bool state){
        hasHealthButtonClicked=state;
        //TODO: similar to Evolution
        
    }

}
