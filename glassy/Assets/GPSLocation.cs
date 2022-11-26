using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GPSLocation : MonoBehaviour
{
    //UI Text to show GPS values
    public TMP_Text GPSStatus;
    public TMP_Text latitudeValue;
    public TMP_Text longitudeValue;
    public TMP_Text altitudeValue;
    public TMP_Text horizontalAccuracyValue;

    private void Start()
    {
       
        StartCoroutine(GPSLoc());
        
    }//end of Start

    IEnumerator GPSLoc()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser){
            
            yield break;
        }

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
           
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            GPSStatus.text = "Time out";
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            GPSStatus.text = "Unable to determine device location";
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            //Call UpdateGPSData first time after 0.5sec and then call UpdateGPSData after 1 sec and repeat it.
            GPSStatus.text = "Running";
            InvokeRepeating("UpdateGPSData", 0.5f, 1f);

        }

        // Stop service if there is no need to query location updates continuously
        //Input.location.Stop();
    }//end of GPSLoc

    //update values on UI Text fields
    private void UpdateGPSData()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            GPSStatus.text = "Running";
            latitudeValue.text = Input.location.lastData.latitude.ToString();
            longitudeValue.text = Input.location.lastData.longitude.ToString();
            altitudeValue.text = Input.location.lastData.altitude.ToString();
            horizontalAccuracyValue.text = Input.location.lastData.horizontalAccuracy.ToString();
        }
        else if(Input.location.status == LocationServiceStatus.Failed)
        {
            GPSStatus.text = "Failed";
        }
        else if(Input.location.status == LocationServiceStatus.Stopped)
            GPSStatus.text = "Stopped";
        else
            GPSStatus.text = "Initializing";
    }//end of UpdateGPSData

}//end of class