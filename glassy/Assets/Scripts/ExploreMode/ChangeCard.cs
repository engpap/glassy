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

    // Evolution Section
    public  Button EvolutionButton;
    private bool hasEvolutionButtonClicked = false;
    public GameObject EvolutionPanel;
    
    public GameObject EvolutionObjects;




    // Health Section
    public Button HealthButton;
    private bool hasHealthButtonClicked = false;
    public GameObject HealthPanel;
    public GameObject HealthObjects;

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

        // Hide Reset 3D Models Position button
        setActive_ResetItemsButton(false);


        //---- Add Buttons Listeners
        DetailsButton.onClick.AddListener(delegate{ChangeImage("Details");}); 
        EvolutionButton.onClick.AddListener(delegate{ChangeImage("Evolution");});   
        HealthButton.onClick.AddListener(delegate{ChangeImage("Health");}); 
        //----------------------------------------------------------------
    }

    void ChangeImage(string buttonName){
        
        if(buttonName=="Details"){
            Debug.Log(">>> ExploreMode: Clicked Deatails Button");
            Console.WriteLine("Details button is selected");
            hasDetailsButtonClicked=!hasDetailsButtonClicked;
            setActive_DetailsFunctionality(hasDetailsButtonClicked);
            setActive_EvolutionFunctionality(false);
            setActive_HealthFunctionality(false);
            setActive_ResetItemsButton(false);
            
        }
        if(buttonName=="Evolution"){
            Debug.Log(">>> ExploreMode: Clicked Evolution Button");
            Console.WriteLine("Evolution button is selected");
            hasEvolutionButtonClicked=!hasEvolutionButtonClicked;
            setActive_EvolutionFunctionality(hasEvolutionButtonClicked);
            setActive_ResetItemsButton(hasEvolutionButtonClicked);
            setActive_DetailsFunctionality(false);
            setActive_HealthFunctionality(false);
            
        }
        if(buttonName=="Health"){
            Debug.Log(">>> ExploreMode: Clicked Health Button");
            Console.WriteLine("Health button is selected");
            hasHealthButtonClicked=!hasHealthButtonClicked;
            setActive_HealthFunctionality(hasHealthButtonClicked);
            setActive_ResetItemsButton(hasHealthButtonClicked);
            setActive_EvolutionFunctionality(false);
            setActive_DetailsFunctionality(false);
        }
    }


    /**
    *   Hide buttons that should be activated when Details button is clicked
    */
    private void setActive_DetailsFunctionality(bool state){
        hasDetailsButtonClicked=state;
        DetailsPanel.SetActive(state);
    }

    /**
    *   Hide buttons that should be activated when Evolution button is clicked
    */
    private void setActive_EvolutionFunctionality(bool state){
        hasEvolutionButtonClicked=state;
        EvolutionPanel.SetActive(state);
        EvolutionObjects.SetActive(state);  
    }


    /**
    *   Hide buttons that should be activated when Health button is clicked
    */
    private void setActive_HealthFunctionality(bool state){
        hasHealthButtonClicked=state;
        HealthPanel.SetActive(state);
        HealthObjects.SetActive(state);
    }

    private void setActive_ResetItemsButton(bool state){
        ResetItemsButton.gameObject.SetActive(state);
    }

}
