using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCard : MonoBehaviour
{
    public GameObject rawImage;
    public void ShowCard()
    {   
        if(rawImage!=null)
            rawImage.SetActive(true);
    }
}
