using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NRKernal;
public class PlayScript : MonoBehaviour
{
    private int count;
    public Button countPlant;
    public TMP_Text buttonText;
    public Image image;
    public Sprite lavandula, ginkgo, appleblossom, weepingwillow,magnolia;
    
    // Start is called before the first frame update
    void Start()
    {
        image.sprite=ginkgo;
        count=0;   
        
    }

    public void UpdateCount(){
        
        if(count<5){
            count++;
            buttonText.text = "Plant Found: "+count+"/5";

            switch (count)
            {
                case 1:
                    image.sprite=magnolia;
                    break;
                case 2:
                    image.sprite=appleblossom;
                    break;
                case 3:
                    image.sprite=weepingwillow;
                    break;
                case 4:
                    image.sprite=lavandula;
                    break;
                default:
                break;
            }
        }
    }
}
