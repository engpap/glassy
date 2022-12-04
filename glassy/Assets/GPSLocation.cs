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
        Coordinate[] cordinate=new Coordinate[5];
        cordinate[0].latitude=45.484835f;   //SALVIA RUSSA
        cordinate[0].longitude=9.193702f;
        cordinate[1].latitude=45.484531f;   //SALICE PIANGENTE 
        cordinate[1].longitude=9.191907f;
        cordinate[2].latitude=45.484827f;   //FRASSINO
        cordinate[2].longitude=9.192582f;
        cordinate[3].latitude=45.483627f;   //PAPAVERO
        cordinate[3].longitude=9.193029f;
        cordinate[4].latitude=45.484933f;   //IRIS SIBIRICA
        cordinate[4].longitude=9.193889f;
        
        if (Input.location.status == LocationServiceStatus.Running)
        {d
            GPSStatus.text = "Running";
            for(int i=0;i<5;i++){
                if(cordinate[i].latitude<45.485366)
            }


            latitudeValue = Input.location.lastData.latitude;
            longitudeValue = Input.location.lastData.longitude;
           
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