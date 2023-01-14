using System.Collections.Generic;
using UnityEngine;

namespace NRKernal.NRExamples{
public class GameTrackingImageController : NRKernal.NRExamples.TrackingImageController
{
    private int NUMBER_OF_RECOGNIZABLE_IMAGES = 3;

    private Dictionary<int, bool> hasAlreadyBeenRecognized = new Dictionary<int, bool>();

    public void Start()
    {
        Debug.Log(">>> GameTrackingImageController, Start()");
        initImageTrackingSession();
        initHasAlreadyBeenRecognized();
    }

    public void initHasAlreadyBeenRecognized()
    {
        for (int i = 0; i < NUMBER_OF_RECOGNIZABLE_IMAGES; i++)
        {
            hasAlreadyBeenRecognized[i] = false;
        }
        Debug.Log(
            ">>> GameTrackingImageController, Start(): hasAlreadyBeenRecognized Dictionary initialized!"
        );
    }

    /// <summary> Updates this object. </summary>
    public void Update()
    {
#if !UNITY_EDITOR
        // Check that motion tracking is tracking.
        if (NRFrame.SessionStatus != SessionState.Running)
        {
            return;
        }
#endif
        // Get updated augmented images for this frame.
        NRFrame.GetTrackables<NRTrackableImage>(base.m_TempTrackingImages, NRTrackableQueryFilter.All);

        foreach (var image in m_TempTrackingImages)
        {
            if (
                image.GetTrackingState() == TrackingState.Tracking
                && NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode
                    == TrackableImageFindingMode.ENABLE
            )
            {
                if (hasAlreadyBeenRecognized[image.GetDataBaseIndex()] == false)
                {
                    GameTrackingImageVisualizer visualizer = (GameTrackingImageVisualizer)Instantiate(
                        TrackingImageVisualizerPrefab,
                        image.GetCenterPose().position,
                        image.GetCenterPose().rotation
                    );
                    visualizer.Image = image;
                    visualizer.transform.parent = transform;
                    Debug.Log(">>> GameTrackingImageController, Update(): Created new Visualizer!");

                    hasAlreadyBeenRecognized[image.GetDataBaseIndex()] =
                        visualizer.incrementCounter();

                    Destroy(visualizer.gameObject);
                    Debug.Log(
                        ">>> GameTrackingImageController, Update(): in if; Destroyed Visualizer"
                    );
                }
                else
                {
                    Debug.Log(
                        ">>> GameTrackingImageController, Update(): Image already recognized!"
                    );
                }
            }
        }
    }
}
}