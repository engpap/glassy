using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSLocation : MonoBehaviour
{
   
    public static GPSLocation Instance {set;get;}

    public float latitude;
    public float longitude;

    private void Start()
    {
        Instance=this;
        DontDestroyOnLoad(gameObject);
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
          
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
           
            yield break;
        }
        else
        {

            latitude=Input.location.lastData.latitude;
            longitude= Input.location.lastData.longitude;

            yield break;
            // Access granted and location value could be retrieved
            //Call UpdateGPSData first time after 0.5sec and then call UpdateGPSData after 1 sec and repeat it.
           // InvokeRepeating("UpdateGPSData", 0.5f, 1f);
            
        }

        // Stop service if there is no need to query location updates continuously
        //Input.location.Stop();
    }

  
    /*private void UpdateGPSData()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
           
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
*/
}//end of class