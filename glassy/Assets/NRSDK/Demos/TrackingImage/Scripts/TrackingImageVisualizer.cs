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

        public void Start(){
            var config = NRSessionManager.Instance.NRSessionBehaviour.SessionConfig;
            config.ImageTrackingMode = TrackableImageFindingMode.DISABLE;
            NRSessionManager.Instance.SetConfiguration(config);
            Debug.Log(">>> Disable Image Tracking at start of Visualizer");
        }
        public void Update()
        {

            if(Image!=null){
                Debug.Log(">>> "+NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode);
                if((Image.GetDataBaseIndex()==0) && (ImageToFind.sprite==salvia)){
                    setInteractable();
                    Debug.Log(">>> Recognized image, database index 0 ");
                }            
                if((Image.GetDataBaseIndex()==1) && (ImageToFind.sprite==papavero)){
                    setInteractable();
                    Debug.Log(">>> Recognized image, database index 1 ");
                }
                if((Image.GetDataBaseIndex()==2) && (ImageToFind.sprite==frassino)){
                    setInteractable();
                    Debug.Log(">>> Recognized image, database index 2 ");
                }
                if((Image.GetDataBaseIndex()==3) && (ImageToFind.sprite==weepingwillow)) {
                    setInteractable();
                    Debug.Log(">>> Recognized image, database index 3 ");
                }
                if((Image.GetDataBaseIndex()==4) && (ImageToFind.sprite==iris)) {
                    setInteractable();
                    Debug.Log(">>> Recognized image, database index 4 ");
                }    
                Debug.Log(">>> "+NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode);       
                return;

            }
            
        }

       public void setInteractable(){
        Debug.Log(">>> setInteractable(): Increase the counter");
        CountPlantButton.interactable=true;
        CountPlantButton.onClick.Invoke();
        CountPlantButton.interactable=false;  

        // Disable Image Tracking      
        var config = NRSessionManager.Instance.NRSessionBehaviour.SessionConfig;
        config.ImageTrackingMode = TrackableImageFindingMode.DISABLE;
        NRSessionManager.Instance.SetConfiguration(config);
        Debug.Log(">>> setInteractable(): Disable Image Tracking");
        GameObject FitToScan=GameObject.Find("FitToScan");  
        FitToScan.SetActive(false);
        GameObject ButtonImageScan=GameObject.Find("ScanImage");  
        Button button=ButtonImageScan.GetComponent<Button>();
        button.interactable=true;
        Debug.Log(">>> setInteractable(): Scan Image Button is now interactable again");
       } 
        
    }
