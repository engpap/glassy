using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;
using UnityEngine.UI;

public class GameTrackingImageVisualizer : TrackingImageVisualizer
{
    public GameObject CountPlant;
    public Image ImageToFind;
    public Sprite papavero,
        salvia,
        frassino;
    public GameObject principal;
    public GameObject ImageScan,
        FitToScan;
    public GameObject PlantButton,
        HintsButton,
        Settings,
        MapButton;

    //function that recognize image and increment the counter of plant found.
    public bool incrementCounter()
    {
        Debug.Log(">>> incrementCounter(): This method has been called!");
        if (Image != null)
        {
            Debug.Log(">>> incrementCounter(): index: " + Image.GetDataBaseIndex());
            if ((Image.GetDataBaseIndex() == 0) && (ImageToFind.sprite == salvia))
            {
                //Debug.Log(">>> Index 0, State of Image Tracking: "+NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode);
                setInteractable();
                Debug.Log(">>> Recognized Salvia image, database index 0 ");
                //Debug.Log(">>> Index 0, State of Image Tracking: "+NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode);
                return true;
            }
            else if ((Image.GetDataBaseIndex() == 1) && (ImageToFind.sprite == papavero))
            {
                //Debug.Log(">>> Index 1, State of Image Tracking: "+NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode);
                setInteractable();
                Debug.Log(">>> Recognized Papavero image, database index 1 ");
                //Debug.Log(">>> Index 1, State of Image Tracking: "+NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode);
                return true;
            }
            else if ((Image.GetDataBaseIndex() == 2) && (ImageToFind.sprite == frassino))
            {
                //Debug.Log(">>> Index 2, State of Image Tracking: "+NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode);
                setInteractable();
                Debug.Log(">>> Recognized Frassino image, database index 2 ");
                //Debug.Log(">>> Index 2, State of Image Tracking: "+NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            Debug.Log(">>> NRTrackableImage is null!");
            return false;
        }
    }

    public void setInteractable()
    {
        CountPlant.GetComponent<Button>().interactable = true;
        CountPlant.GetComponent<Button>().onClick.Invoke();
        CountPlant.GetComponent<Button>().interactable = false;
        Debug.Log(">>> setInteractable(): Counter increased!");

        DisableImageTracking();
        Debug.Log(">>> setInteractable(): Image Tracking disabled!");

        FitToScan.SetActive(false);
        PlantButton.SetActive(true);
        MapButton.SetActive(true);
        HintsButton.SetActive(true);
        Settings.SetActive(true);
        Debug.Log(">>> setInteractable(): FitToScan windows is now disctivated!");

        ImageScan.GetComponent<Button>().interactable = true;
        Debug.Log(">>> setInteractable(): Scan Image Button is now interactable again!");
    }
}
