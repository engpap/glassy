using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;
using UnityEngine.UI;

public class TrackingImageVisualizer : MonoBehaviour
    {
        public NRTrackableImage Image;
        public GameObject CountPlant;
        public Image ImageToFind;
        public Sprite iris, salvia, frassino, weepingwillow,papavero;
        public GameObject principal;
        public GameObject ImageScan,FitToScan;

        public TrackingImageVisualizer(){
            Debug.Log(">>> TrackingImageVisualizer, Start(): Disabled Image Tracking at start of Visualizer");
        }


        //function that recognize image and increment the counter of plant found.
        public bool incrementCounter(){
            Debug.Log(">>> incrementCounter(): This method has been called!");
            if(Image!=null){

                Debug.Log(">>> incrementCounter(): index: "+Image.GetDataBaseIndex());
                if((Image.GetDataBaseIndex()==0) && (ImageToFind.sprite==salvia)){
                    //Debug.Log(">>> Index 0, State of Image Tracking: "+NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode);
                    setInteractable();
                    Debug.Log(">>> Recognized Salvia image, database index 0 ");
                    //Debug.Log(">>> Index 0, State of Image Tracking: "+NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode);
                    return true;
                }            
                else if((Image.GetDataBaseIndex()==1) && (ImageToFind.sprite==papavero)){
                    //Debug.Log(">>> Index 1, State of Image Tracking: "+NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode);
                    setInteractable();
                    Debug.Log(">>> Recognized Papavero image, database index 1 ");
                    //Debug.Log(">>> Index 1, State of Image Tracking: "+NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode);
                    return true;
                }
                else if((Image.GetDataBaseIndex()==2) && (ImageToFind.sprite==frassino)){
                    //Debug.Log(">>> Index 2, State of Image Tracking: "+NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode);
                    setInteractable();
                    Debug.Log(">>> Recognized Frassino image, database index 2 ");
                    //Debug.Log(">>> Index 2, State of Image Tracking: "+NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode);
                    return true;
                }
                else if((Image.GetDataBaseIndex()==3) && (ImageToFind.sprite==weepingwillow)) {
                    //Debug.Log(">>> Index 3, State of Image Tracking: "+NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode);
                    setInteractable();
                    Debug.Log(">>> Recognized Weeping Willow image, database index 3 ");
                    //Debug.Log(">>> Index 3, State of Image Tracking: "+NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode);
                    return true;
                }
                else if((Image.GetDataBaseIndex()==4) && (ImageToFind.sprite==iris)) {
                    //Debug.Log(">>> Index 4, State of Image Tracking: "+NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode);
                    setInteractable();
                    Debug.Log(">>> Recognized Iris image, database index 4 ");
                    //Debug.Log(">>> Index 4, State of Image Tracking: "+NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode);
                    return true;
                } 
                else{
                    Debug.Log(">>> Recognized wrong plant! You have to recognize: "+ImageToFind.sprite.ToString());
                    //Debug.Log(">>> State of Image Tracking: "+NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode);
                    return false;
                }
            }else{
                Debug.Log(">>> NRTrackableImage is null!");
                return false;
            }
            
        }

        public void setInteractable(){

            CountPlant.GetComponent<Button>().interactable=true;
            CountPlant.GetComponent<Button>().onClick.Invoke();
            CountPlant.GetComponent<Button>().interactable=false;  
            Debug.Log(">>> setInteractable(): Counter increased!");

            DisableImageTracking();
            Debug.Log(">>> setInteractable(): Image Tracking disabled!");
 
            FitToScan.SetActive(false);
            Debug.Log(">>> setInteractable(): FitToScan windows is now disctivated!");
            
            ImageScan.GetComponent<Button>().interactable=true;
            Debug.Log(">>> setInteractable(): Scan Image Button is now interactable again!");
       } 

        private void DisableImageTracking(){
        var config = NRSessionManager.Instance.NRSessionBehaviour.SessionConfig;
        config.ImageTrackingMode = TrackableImageFindingMode.DISABLE;
        NRSessionManager.Instance.SetConfiguration(config);
       }
    
        
    }
        

