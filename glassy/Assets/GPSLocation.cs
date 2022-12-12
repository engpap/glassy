using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GPSLocation : MonoBehaviour
{
    
    public struct Coordinate
    {
    public float latitude;
    public float longitude;
    }

    //UI Text to show GPS values
    float latitude;
    float longitude;
    float width,height;
    float deltalat, deltalong;
    float posx,posy;
    public Image map;
    int passix,passiy;
    public GameObject pointer;
    Coordinate[] coordinate={new Coordinate(),new Coordinate(),new Coordinate(),new Coordinate()};

    

    private void Start()
    {
        RectTransform rt = map.rectTransform;
        width=rt.rect.width;
        height=rt.rect.height;
        coordinate[0].latitude=45.48601f; //angolo in alto a sinistra
        coordinate[0].longitude=9.18942f;
        coordinate[1].latitude=45.48601f;//angolo in alto a destra
        coordinate[1].longitude=9.19555f;
        coordinate[2].latitude=45.48268f;//angolo in basso a destra
        coordinate[2].longitude=9.19555f;
        coordinate[3].latitude=45.48268f;//angolo in basso a sinistra
        coordinate[3].longitude=9.18942f;
        deltalat=coordinate[0].latitude-coordinate[2].latitude;    //3.33e-03
        deltalong=coordinate[1].longitude-coordinate[0].longitude; //6.13e-03
        passix=(int)width;
        passiy=(int)height;
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
            // Access granted and location value could be retrieved
            //Call UpdateGPSData first time after 0.5sec and then call UpdateGPSData after 1 sec and repeat it.
          
            InvokeRepeating("UpdateGPSData", 0.5f, 5f);

        }

        // Stop service if there is no need to query location updates continuously
        //Input.location.Stop();
    }//end of GPSLoc

    //update values on UI Text fields
    private void UpdateGPSData()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
        latitude =Input.location.lastData.latitude;
        longitude=Input.location.lastData.longitude;
        posx=((longitude-coordinate[0].longitude)/deltalong)*passix;
        posy=((latitude-coordinate[3].latitude)/deltalat)*passiy;
        RectTransform rectT=pointer.GetComponent<RectTransform>();
        Vector3 newPos = new Vector3(posx-366.665f,posy-275,0);
        pointer.transform.localPosition = newPos;
        }
    
    }//end of UpdateGPSData

}//end of class