using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;
using UnityEngine.UI;

public class TrackingImageVisualizer : MonoBehaviour
    {
        public NRTrackableImage Image;
        public Button Playbutton;
        public Image image;
        public Sprite iris, salvia, frassino, weepingwillow,papavero;
        public void Update()
        {
            if(Image!=null){
                
                if((Image.GetDataBaseIndex()==0) && (image.sprite==salvia)){
                    setInteractable();
                }            
                else if((Image.GetDataBaseIndex()==1) && (image.sprite==papavero)){
                    setInteractable();
                }
                else if((Image.GetDataBaseIndex()==2) && (image.sprite==frassino)){
                    setInteractable();
                }
                else if((Image.GetDataBaseIndex()==3) && (image.sprite==weepingwillow)) {
                    setInteractable();
                }
                else if((Image.GetDataBaseIndex()==4) && (image.sprite==iris)) {
                    setInteractable();
                }           
                return;
            }
            
        }

       public void setInteractable(){
        Playbutton.interactable=true;
        Playbutton.onClick.Invoke();
       } 
        
    }
