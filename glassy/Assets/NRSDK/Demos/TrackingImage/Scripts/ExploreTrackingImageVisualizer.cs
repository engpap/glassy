using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;
using UnityEngine.UI;

public class ExploreTrackingImageVisualizer : TrackingImageVisualizer
{
    public GameObject fitToScanCanvas;
    public GameObject exploreCanvas;
    public GameObject hideButton;
    public GameObject GrabbableItemsParentObject;

    public GameObject[] DetailsObjects;
    public Sprite[] LavanderDetailsSprites;
    public Sprite[] AppleTreeDetailsSprites;
    public Sprite[] LotusDetailsSprites;

    public GameObject BloomingTimeObject;
    public Sprite[] BloomingTimeSprites;
    public GameObject[] EvolutionGrabbableItems;

    public GameObject[] HealthObjects;
    public Sprite[] LavanderHealthSprites;
    public Sprite[] AppleTreeHealthSprites;
    public Sprite[] LotusHealthSprites;
    public GameObject[] HealthGrabbableItems;


    public void showContentBasedOnRecognizedImage()
    {
        Debug.Log(">>> ShowContentBasedOnRecognizedImage:");
        if (Image != null)
        {
            if (Image.GetDataBaseIndex() == 0)
            {
                Debug.Log(">>> Showing Lavander content...");
                showContentOfPlant("Lavander", LavanderDetailsSprites, LavanderHealthSprites);
                return;
            }
            else if (Image.GetDataBaseIndex() == 1)
            {
                Debug.Log(">>> Showing Apple Tree content...");
                showContentOfPlant("AppleTree", AppleTreeDetailsSprites, AppleTreeHealthSprites);
                return;
            }
            else if (Image.GetDataBaseIndex() == 2)
            {
                Debug.Log(">>> Showing Lotus content...");
                showContentOfPlant("Lotus", LotusDetailsSprites, LotusHealthSprites);
                return;
            }
            else
            {
                Debug.Log(">>> For this plant Explore Mode is not supported yet!");
                return;
            }
        }
        else
        {
            Debug.Log(">>> NRTrackableImage is null!");
            return;
        }
    }

    private void showContentOfPlant(
        string plantName,
        Sprite[] PlantDetailsSprites,
        Sprite[] PlantHealthSprites
    )
    {
        // Image Tracking is disabled since we have recongnized the plant, se we now want to only display content of the plant
        DisableImageTracking();

        fitToScanCanvas.SetActive(false);

        exploreCanvas.SetActive(true);
        hideButton.SetActive(true);
        GrabbableItemsParentObject.SetActive(true);

        // Set Details //TODO: refactor with loop on length
        DetailsObjects[0].GetComponent<Image>().sprite = PlantDetailsSprites[0];
        DetailsObjects[1].GetComponent<Image>().sprite = PlantDetailsSprites[1];
        DetailsObjects[2].GetComponent<Image>().sprite = PlantDetailsSprites[2];

        int index = getGameObjectArrayIndexByPlantName(plantName);
        // Set Evolution
        Set3DModelsActiveOnlyGivenIndex(index, EvolutionGrabbableItems);
        BloomingTimeObject.GetComponent<Image>().sprite = BloomingTimeSprites[index];

        // Set Health //TODO: refactor with loop on length
        Set3DModelsActiveOnlyGivenIndex(index, HealthGrabbableItems);
        HealthObjects[0].GetComponent<Image>().sprite = PlantHealthSprites[0];
        HealthObjects[1].GetComponent<Image>().sprite = PlantHealthSprites[1];
    }

    private void Set3DModelsActiveOnlyGivenIndex(int index, GameObject[] gameObjects)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (i != index)
                gameObjects[i].SetActive(false);
            else
                gameObjects[i].SetActive(true);
        }
    }

    private int getGameObjectArrayIndexByPlantName(string plantName)
    {
        if (plantName == "Lavander")
            return 0;
        else if (plantName == "AppleTree")
            return 1;
        else if (plantName == "Lotus")
            return 2;
        else
            return -1; //TODO: substitute with exception
    }
}
