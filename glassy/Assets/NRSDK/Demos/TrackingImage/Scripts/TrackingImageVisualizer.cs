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
        private int count=0;
        public void Update()
        {
            if(Image!=null){
                
                if((Image.GetDataBaseIndex()==0) && (image.sprite==salvia)){
                    setInteractable();
                }            
                if((Image.GetDataBaseIndex()==1) && (image.sprite==papavero)){
                    setInteractable();
                }
                if((Image.GetDataBaseIndex()==2) && (image.sprite==frassino)){
                    setInteractable();
                }
                if((Image.GetDataBaseIndex()==3) && (image.sprite==weepingwillow)) {
                    setInteractable();
                }
                if((Image.GetDataBaseIndex()==4) && (image.sprite==iris)) {
                    setInteractable();
                }           
                return;
            GameObject FitToScan=GameObject.Find("FitToScan");  
            FitToScan.SetActive(false);
            var config = NRSessionManager.Instance.NRSessionBehaviour.SessionConfig;
            config.ImageTrackingMode = TrackableImageFindingMode.DISABLE;
            NRSessionManager.Instance.SetConfiguration(config);
            }
            
        }

       public void setInteractable(){
        Playbutton.interactable=true;
        Playbutton.onClick.Invoke();
        Playbutton.interactable=false;
                
       } 
        
    }
