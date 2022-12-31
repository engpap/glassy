using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class utility : MonoBehaviour
{
    public GameObject principal;
    private bool flagTutorial;
    private bool flagTutorialExploreMode;
    public GameObject items;
    
    public void returnFromOptionExploreMode(){
         if(flagTutorialExploreMode)
        {
            GameObject tutorial = principal.transform.Find("Tutorial").gameObject;
            tutorial.SetActive(true);
        }
        else
        {
            GameObject explore=principal.transform.Find("Explore").gameObject;
            explore.SetActive(true);
            items.SetActive(true);
            
        }
    }
    //PlayMode
    public void returnFromOption(){
        
        if(flagTutorial)
        {
            GameObject tutorial = principal.transform.Find("Canvas_Tutorial").gameObject;
            tutorial.SetActive(true);
        }
        else
        {
            GameObject playmode=principal.transform.Find("PlayModeView").gameObject;
            playmode.SetActive(true);
        }

    }
    //PlayMode
    public void onClickOption(){
        GameObject tutorial=principal.transform.Find("Canvas_Tutorial").gameObject;
        if(tutorial.activeSelf)
            {
                flagTutorial=true;
                tutorial.SetActive(false);
            }
        else
            flagTutorial=false;
            

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