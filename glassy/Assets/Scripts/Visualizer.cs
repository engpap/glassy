using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;
public class TrackingImageVisualizer : MonoBehaviour
{
    public NRTrackableImage image;
    public GameObject cube;

  
    void Update()
    {
        if(image==null)
        {   cube.SetActive(false);
            return;
        }

        var center= image.GetCenterPose();
        transform.position=center.position;
        transform.rotation=center.rotation;
        cube.SetActive(true);
    }
}
