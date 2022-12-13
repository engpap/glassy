using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class utility : MonoBehaviour
{
    public GameObject principal;
    private bool flagTutorial;
    private bool flagTutorialExploreMode;
    
    public void returnFromOptionExploreMode(){
         if(!flagTutorialExploreMode)
        {
            GameObject tutorial = principal.transform.Find("Tutorial").gameObject;
            tutorial.SetActive(true);
            flagTutorialExploreMode=true;
        }
        else
        {
            GameObject explore=principal.transform.Find("Explore").gameObject;
            explore.SetActive(true);
        }
    }
    public void returnFromOption(){
        
        if(!flagTutorial)
        {
            GameObject tutorial = principal.transform.Find("Canvas_Tutorial").gameObject;
            tutorial.SetActive(true);
            flagTutorial=true;
        }
        else
        {
            GameObject playmode=principal.transform.Find("PlayModeView").gameObject;
            playmode.SetActive(true);
        }

    }

    public void onClickOption(){
        GameObject tutorial=principal.transform.Find("Canvas_Tutorial").gameObject;
        if(!tutorial.activeSelf)
            flagTutorial=false;
        else
            {
                flagTutorial=true;
                tutorial.SetActive(false);
            }

    }

    public void onClickOptionExploreMode(){
        GameObject tutorial=principal.transform.Find("Tutorial").gameObject;
        if(!tutorial.activeSelf)
            flagTutorialExploreMode=false;
        else
            {
                flagTutorialExploreMode=true;
                tutorial.SetActive(false);
            }

    }
   
}