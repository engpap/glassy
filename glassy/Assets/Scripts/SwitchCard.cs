using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCard : MonoBehaviour
{
    //public Dictionary<String,GameObject> cards = new Dictionary<String,GameObject>();
    //public GameObject shownCard = new GameObject();
   // Image m_Image;
    //public Sprite m_Sprite;
    private Sprite img1;
    public GameObject MyImage;

    /*void Start(){
        m_Image=GetComponent<Image>();
    }*/
    public void ShowMyCard(){
        MyImage.AddComponent(typeof(Image));
        img1 = Resources.Load<Sprite>("../Images/edera.png");
        MyImage.GetComponent<Image>().sprite = img1;
        Debug.Log("Test script started");
    }
    /*public void ShowCard(string buttonName)
    {   
        //if(rawImage!=null)
        //    rawImage.SetActive(true);
        if(buttonName==ButtonsNames.DETAILS){
            Debug.Log(">>> "+ButtonsNames.DETAILS+" has been clicked");
            print("AAAAAAAAAAAAA");
            m_Image.sprite=m_Sprite;
            //shownCard=cards[buttonName];
        }
        else if(buttonName==ButtonsNames.EVOLUTION){
            Debug.Log(">>> "+ButtonsNames.DETAILS+" has been clicked");
            //shownCard=cards[buttonName];
        }
        else if(buttonName==ButtonsNames.HEALTH){
            Debug.Log(">>> "+ButtonsNames.DETAILS+" has been clicked");
            //shownCard=cards[buttonName];
        }
        else{
            Debug.Log(">>> Situation not allowed");
        }
        
    }*/
}
