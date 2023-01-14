using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NRKernal;

public struct Coordinate
{
    public float latitude;
    public float longitude;
}


public class PlayScript : MonoBehaviour
{
    public static PlayScript Instance {set;get;}

    bool HintPinPosition;
    int count;
    public Button countPlant;
    public TMP_Text buttonText;
    public Image image;
    public Sprite papavero, salvia, frassino;
    Coordinate[] coordinate={new Coordinate(),new Coordinate(),new Coordinate()};
    
    // Start is called before the first frame update
    void Start()
    {
        HintPinPosition=false;
        Instance=this;
        DontDestroyOnLoad(gameObject);
        //CAMBIARE LE COORDINATE PER L'ESAME (AULA ALARIO)
        coordinate[0].latitude=45.484835f;   //SALVIA RUSSA
        coordinate[0].longitude=9.193702f;
        coordinate[1].latitude=45.483627f;   //PAPAVERO
        coordinate[1].longitude=9.193029f;
        coordinate[2].latitude=45.484827f;   //FRASSINO
        coordinate[2].longitude=9.192582f;
        image.sprite=salvia;
        count=0;
    }

    public void UpdateCount(){
        //when you find a plant the counter in the upper left will be increased 
        FindObject(this,"Quad1_black").SetActive(false);
        FindObject(this,"Quad1_red").SetActive(false);
        FindObject(this,"Quad2_black").SetActive(false);
        FindObject(this,"Quad2_red").SetActive(false);
        FindObject(this,"Quad3_black").SetActive(false);
        FindObject(this,"Quad3_red").SetActive(false);
        FindObject(this,"Quad4_black").SetActive(false);
        FindObject(this,"Quad4_red").SetActive(false);
        HintPinPosition=false;
        GameObject panelRedArea=FindObject(this,"panel_hint3");
        Button button3=panelRedArea.GetComponent<Button>();
        button3.interactable=true;
        GameObject panelColorPin=FindObject(this,"panel_hint2");
        Button button2=panelColorPin.GetComponent<Button>();
        button2.interactable=true;
        GameObject panelBlackArea=FindObject(this,"panel_hint1");
        Button button1=panelBlackArea.GetComponent<Button>();
        button1.interactable=true;
        
        if(count<2){
            count++;
            //change image on the plant to find box.
            FindObject(this,"PlantFound").SetActive(true);
            buttonText.text = "Plant Found: "+count+"/3";
            switch (count)
            {
                case 1:
                    image.sprite=papavero;
                    break;
                case 2:
                    image.sprite=frassino;
                    break;
                default:
                    break;
            }
        }
        else{
            //when u find all the plants a game complete object will be shown
            FindObject(this,"GameComplete").SetActive(true);
            FindObject(this,"PlayModeView").SetActive(false);
            FindObject(this,"PlantView").SetActive(false);
            FindObject(this,"HintsView").SetActive(false);
            FindObject(this,"OptionView").SetActive(false);
            FindObject(this,"MapView").SetActive(false);
            FindObject(this,"Settings").SetActive(false);
            FindObject(this,"PlantFound").SetActive(false);
        }
    }

    //Red Area hint
    public void RedArea(){
        GameObject panelRedArea=GameObject.Find("panel_hint3");
        Button button=panelRedArea.GetComponent<Button>();
        button.interactable=false;
        if((coordinate[count].latitude>=45.484757f) && (coordinate[count].latitude<=45.485765f) && (coordinate[count].longitude>=9.189828f) && (coordinate[count].longitude<=9.192507f))
            FindObject(this,"Quad1_red").SetActive(true);
        if((coordinate[count].latitude>=45.484757f) && (coordinate[count].latitude<=45.485765f) && (coordinate[count].longitude>=9.192507f) && (coordinate[count].longitude<=9.194318f))
            FindObject(this,"Quad2_red").SetActive(true);
        if((coordinate[count].latitude>=45.483177f) && (coordinate[count].latitude<=45.484757f) && (coordinate[count].longitude>=9.189828f) && (coordinate[count].longitude<=9.192507f))
            FindObject(this,"Quad3_red").SetActive(true);
        if((coordinate[count].latitude>=45.483177f) && (coordinate[count].latitude<=45.484757f) && (coordinate[count].longitude>=9.192507f) && (coordinate[count].longitude<=9.194318f))
            FindObject(this,"Quad4_red").SetActive(true);

    }

    //Dark area hint
    public void DarkArea(){
        GameObject panelBlackArea=FindObject(this,"panel_hint1");
        Button button1=panelBlackArea.GetComponent<Button>();
        button1.interactable=false;
         if((coordinate[count].latitude>=45.484757f) && (coordinate[count].latitude<=45.485765f) && (coordinate[count].longitude>=9.189828f) && (coordinate[count].longitude<=9.192507f))
            {
                int num=RandomRangeExcept(1,4,1);
                string quad="Quad"+num+"_black";
                FindObject(this,quad).SetActive(true);
            }
        if((coordinate[count].latitude>=45.484757f) && (coordinate[count].latitude<=45.485765f) && (coordinate[count].longitude>=9.192507f) && (coordinate[count].longitude<=9.194318f))
            {
                int num=RandomRangeExcept(1,4,2);
                string quad="Quad"+num+"_black";
                FindObject(this,quad).SetActive(true);
            }
        if((coordinate[count].latitude>=45.483177f) && (coordinate[count].latitude<=45.484757f) && (coordinate[count].longitude>=9.189828f) && (coordinate[count].longitude<=9.192507f))
            {
                int num=RandomRangeExcept(1,4,3);
                string quad="Quad"+num+"_black";
                FindObject(this,quad).SetActive(true);
            }
        if((coordinate[count].latitude>=45.483177f) && (coordinate[count].latitude<=45.484757f) && (coordinate[count].longitude>=9.192507f) && (coordinate[count].longitude<=9.194318f))
            {
                int num=RandomRangeExcept(1,4,4);
                string quad="Quad"+num+"_black";
                FindObject(this,quad).SetActive(true);
            }

    }

    //Colored position pin hint, we change the value of boolean value HintPinPosition and use it in GPSLocation script
    public void ColoredPinPosition(){

        GameObject panelColorPin=FindObject(this,"panel_hint2");
        Button button2=panelColorPin.GetComponent<Button>();
        button2.interactable=false;
        HintPinPosition=true;    
    }

    //Use this function to find an object (even if it isn't active)
    public static GameObject FindObject(PlayScript parent, string name)
    {
        Transform[] trs= parent.GetComponentsInChildren<Transform>(true);
        foreach(Transform t in trs){
            if(t.name == name){
                return t.gameObject;
            }
        }
        return null;
    }

    //generate random number except a value
    public static int RandomRangeExcept (int min, int max,int except ) {
        int number;
    do {
         number = Random.Range (min, max);
    } while (number == except);
    return number;
}

    public bool getHintPinPosition(){
        return HintPinPosition;
    }

    public Coordinate[] getCoordinate(){
        return coordinate;
    }

    public int getCount(){
        return count;
    }

  
}
