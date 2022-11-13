using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCard : MonoBehaviour
{
    public Sprite DetailsSprite;
    public GameObject EvolutionModel;
    public Sprite HealthSprite;
    public Button DetailsButton;
    public Button EvolutionButton;
    public Button HealthButton;


    // Start is called before the first frame update
    void Start()
    {   
        gameObject.SetActive(false);
        DetailsButton.onClick.AddListener(delegate{ChangeImage("Details");});  
        HealthButton.onClick.AddListener(delegate{ChangeImage("Health");}); 
    }

    void ChangeImage(string buttonName){

        if(buttonName=="Details"){
            // EvolutionModel.SetActive(false);
            gameObject.SetActive(true);
            gameObject.GetComponent<Image>().sprite=DetailsSprite;
        }
        if(buttonName=="Evolution"){
            gameObject.SetActive(false);
            EvolutionModel.SetActive(true);
        }
        if(buttonName=="Health"){
            //EvolutionModel.SetActive(true);
            gameObject.SetActive(true);
            gameObject.GetComponent<Image>().sprite=HealthSprite;
        }
    }

}
