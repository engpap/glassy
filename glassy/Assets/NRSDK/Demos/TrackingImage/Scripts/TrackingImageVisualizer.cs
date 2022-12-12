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
              Debug.Log("Ho riconosciuto un immagine");
              imageI.SetActive(true);

              if(Image.GetDataBaseIndex()==0){
                    cubeWhite.SetActive(true);
                    Debug.Log("Image index 0");
              }
                     
              else if(Image.GetDataBaseIndex()==1){
                    cubeRed.SetActive(true);
                    Debug.Log("Image index 1");
              }
              else{
                    Debug.Log("Image 2");
                    cubeGreen.SetActive(true);   
                    }
           
              return;
            }else{
            Debug.Log("Non ho riconosciuto l'image");
            imageI.SetActive(false);
            cubeWhite.SetActive(false);
            cubeRed.SetActive(false);
            cubeGreen.SetActive(false);
            }
            
        }
    }
