using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;
using UnityEngine.UI;
public class TrackingImageVisualizer : MonoBehaviour
    {


        public NRTrackableImage Image;
        public GameObject cubeWhite;
        public GameObject cubeRed;
        public GameObject cubeGreen;
        public GameObject imageI;

        public void Update()
        {
            if(Image!=null){
              imageI.SetActive(true);

              if(Image.GetDataBaseIndex()==0)
                     cubeWhite.SetActive(true);
              else if(Image.GetDataBaseIndex()==1)
                    cubeRed.SetActive(true);
              else
                    cubeGreen.SetActive(true);      
              return;
            }else{
            imageI.SetActive(false);
            cubeWhite.SetActive(false);
            cubeRed.SetActive(false);
            cubeGreen.SetActive(false);
            }
            
        }
    }
