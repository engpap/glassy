using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;
using UnityEngine.UI;

public class TrackingImageVisualizer : MonoBehaviour
    {
        public NRTrackableImage Image;
        public Button CountPlantButton;
        public Image ImageToFind;
        public Sprite iris, salvia, frassino, weepingwillow,papavero;
        private int count=0;
        public void Update()
        {
            if(Image!=null){
                
                if((Image.GetDataBaseIndex()==0) && (ImageToFind.sprite==salvia)){
                    setInteractable();
                }            
                if((Image.GetDataBaseIndex()==1) && (ImageToFind.sprite==papavero)){
                    setInteractable();
                }
                if((Image.GetDataBaseIndex()==2) && (ImageToFind.sprite==frassino)){
                    setInteractable();
                }
                if((Image.GetDataBaseIndex()==3) && (ImageToFind.sprite==weepingwillow)) {
                    setInteractable();
                }
                if((Image.GetDataBaseIndex()==4) && (ImageToFind.sprite==iris)) {
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
        CountPlantButton.interactable=true;
        CountPlantButton.onClick.Invoke();
        CountPlantButton.interactable=false;        
       } 
        
    }
