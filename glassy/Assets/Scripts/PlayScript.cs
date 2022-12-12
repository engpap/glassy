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
    private int count;
    public Button countPlant;
    public TMP_Text buttonText;
    public Image image;
    public Sprite iris, salvia, frassino, weepingwillow,papavero;
    Coordinate[] coordinate={new Coordinate(),new Coordinate(),new Coordinate(),new Coordinate(),new Coordinate()};
    
    // Start is called before the first frame update
    void Start()
    {
        coordinate[0].latitude=45.484835f;   //SALVIA RUSSA
        coordinate[0].longitude=9.193702f;
        coordinate[1].latitude=45.483627f;   //PAPAVERO
        coordinate[1].longitude=9.193029f;
        coordinate[2].latitude=45.484827f;   //FRASSINO
        coordinate[2].longitude=9.192582f;
        coordinate[3].latitude=45.484531f;   //SALICE PIANGENTE 
        coordinate[3].longitude=9.191907f;
        coordinate[4].latitude=45.484933f;   //IRIS SIBIRICA
        coordinate[4].longitude=9.193889f;
        image.sprite=salvia;
        count=0;
    }

    public void UpdateCount(){

        FindObject(this,"Quad1_black").SetActive(false);
        FindObject(this,"Quad1_red").SetActive(false);
        FindObject(this,"Quad2_black").SetActive(false);
        FindObject(this,"Quad2_red").SetActive(false);
        FindObject(this,"Quad3_black").SetActive(false);
        FindObject(this,"Quad3_red").SetActive(false);
        FindObject(this,"Quad4_black").SetActive(false);
        FindObject(this,"Quad4_red").SetActive(false);

        GameObject panelRedArea=FindObject(this,"panel_hint3");
        Button button3=panelRedArea.GetComponent<Button>();
        button3.interactable=true;
        GameObject panelColorPin=FindObject(this,"panel_hint2");
        Button button2=panelColorPin.GetComponent<Button>();
        button2.interactable=true;
        GameObject panelBlackArea=FindObject(this,"panel_hint1");
        Button button1=panelBlackArea.GetComponent<Button>();
        button1.interactable=true;
        
        if(count<5){
            count++;
            buttonText.text = "Plant Found: "+count+"/5";
            switch (count)
            {
                case 1:
                    image.sprite=papavero;
                    break;
                case 2:
                    image.sprite=frassino;
                    break;
                case 3:
                    image.sprite=weepingwillow;
                    break;
                case 4:
                    image.sprite=iris;
                    break;
                default:
                    break;
            }
        }
    }

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
    
    public void ColoredPinPosition(){
        GameObject panelColorPin=FindObject(this,"panel_hint2");
        Button button2=panelColorPin.GetComponent<Button>();
        button2.interactable=false;
        GameObject pointer=GameObject.Find("pointer");
         
         
    }

    
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

    public static int RandomRangeExcept (int min, int max,int except ) {
        int number;
    do {
         number = Random.Range (min, max);
    } while (number == except);
    return number;
}

  
}
