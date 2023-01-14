using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class utility : MonoBehaviour
{
    public GameObject principal;
    private bool flagTutorial;
    private bool flagTutorialExploreMode;
    private bool flagExploreSectionExploreMode;
    public GameObject items;
    
    public void returnFromOptionExploreMode(){
        Debug.Log("Tutorial flag on return: "+flagTutorialExploreMode);
        GameObject tutorial = principal.transform.Find("Tutorial").gameObject;
        GameObject explore=principal.transform.Find("Explore").gameObject;
         if(flagTutorialExploreMode)
        {
            tutorial.SetActive(true);
        }
        else
        {
            if(flagExploreSectionExploreMode){
                explore.SetActive(true);
                items.SetActive(true);  
            }
            else{
                explore.SetActive(false);
                items.SetActive(false);  
            }
        }
    }
    //PlayMode
    public void returnFromOption(){
        GameObject tutorial=principal.transform.Find("Canvas_Tutorial").gameObject;
        GameObject playmode=principal.transform.Find("PlayModeView").gameObject;
        if(flagTutorial)
        {
            tutorial.SetActive(true);
        }
        else
        {
            playmode.SetActive(true);
        }

    }
    //PlayMode
    public void onClickOption(){
        GameObject tutorial=principal.transform.Find("Canvas_Tutorial").gameObject;
        GameObject playmode=principal.transform.Find("PlayModeView").gameObject;
        if(tutorial.activeSelf)
            flagTutorial=true;
        else
            flagTutorial=false;
        tutorial.SetActive(false);
        playmode.SetActive(false);

    }

    public void onClickOptionExploreMode(){
        GameObject tutorial=principal.transform.Find("Tutorial").gameObject;
        GameObject explore=principal.transform.Find("Explore").gameObject;
        if(tutorial.activeSelf)
            flagTutorialExploreMode=true;
        else
            flagTutorialExploreMode=false;
        if(explore.activeSelf)
            flagExploreSectionExploreMode=true;
        else
            flagExploreSectionExploreMode=false;
        explore.SetActive(false);    
        tutorial.SetActive(false);  
        items.SetActive(false);  
        Debug.Log("flagExplore: "+flagTutorialExploreMode);
    }
   
}