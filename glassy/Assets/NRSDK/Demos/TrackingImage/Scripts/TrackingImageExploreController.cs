/****************************************************************************
* Copyright 2019 Nreal Techonology Limited. All rights reserved.
*
* This file is part of NRSDK.
*
* https://www.nreal.ai/
*
*****************************************************************************/

namespace NRKernal.NRExamples
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary> Controller for TrackingImage example. </summary>
    [HelpURL("https://developer.nreal.ai/develop/unity/image-tracking")]
    public class TrackingImageExploreController : MonoBehaviour
    {
        /// <summary> A prefab for visualizing an TrackingImage. </summary>
        public TrackingImageExploreVisualizer TrackingImageExploreVisualizerPrefab;

        /// <summary> The visualizers. </summary>
        private Dictionary<int, TrackingImageVisualizer> m_Visualizers =
            new Dictionary<int, TrackingImageVisualizer>();

        /// <summary> The temporary tracking images. </summary>
        private List<NRTrackableImage> m_TempTrackingImages = new List<NRTrackableImage>();

        private Dictionary<int, bool> hasAlreadyBeenRecognized = new Dictionary<int, bool>();

        public void Start()
        {
            Debug.Log("Start Explore Controller");
            initImageTrackingSession();
            initHasAlreadyBeenRecognized();
        }

        public void initHasAlreadyBeenRecognized()
        {
            for (int i = 0; i < 10; i++)
            {
                hasAlreadyBeenRecognized[i] = false;
            }
            Debug.Log(
                " TrackingImageExampleController, Start(): hasAlreadyBeenRecognized Dictionary initialized!"
            );
        }

        //FOR TESTING WITHOUT GLASSES; TO REMOVE when not needed anymore.
        /*
            private bool flag = true;
            public void Update(){
                if(flag){
                    TrackingImageExploreVisualizer visualizer = (TrackingImageExploreVisualizer)Instantiate(TrackingImageExploreVisualizerPrefab);
                    visualizer.showContentBasedOnRecognizedImage();
                    Debug.Log(">>> TrackingImageExploreController: Visualizer created and called method ");
                    flag=!flag;
                }
            }
    
*/
        /* USE THIS IN REAL ENVIORMENT, WHEN YOU HAVE GLASSES*/
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
            NRFrame.GetTrackables<NRTrackableImage>(
                m_TempTrackingImages,
                NRTrackableQueryFilter.All
            );

            foreach (var image in m_TempTrackingImages)
            {
                if (
                    image.GetTrackingState() == TrackingState.Tracking
                    && NRSessionManager.Instance.NRSessionBehaviour.SessionConfig.ImageTrackingMode
                        == TrackableImageFindingMode.ENABLE
                )
                {
                    // If we are in explore mode, then the image is recognized and proper content shown.
                    if (hasAlreadyBeenRecognized[image.GetDataBaseIndex()] == false)
                    {
                        TrackingImageExploreVisualizer visualizer =
                            (TrackingImageExploreVisualizer)Instantiate(
                                TrackingImageExploreVisualizerPrefab,
                                image.GetCenterPose().position,
                                image.GetCenterPose().rotation
                            );
                        visualizer.Image = image;
                        visualizer.transform.parent = transform;

                        hasAlreadyBeenRecognized[image.GetDataBaseIndex()] =
                            visualizer.showContentBasedOnRecognizedImage();

                        Destroy(visualizer.gameObject);
                        Debug.Log(
                            ">>> TrackingImageExploreController, Update(): in if; Destroyed Visualizer"
                        );
                    }
                }
            }
        }

        /// <summary> Enables the image tracking. </summary>
        public void EnableImageTracking()
        {
            initImageTrackingSession();
            var config = NRSessionManager.Instance.NRSessionBehaviour.SessionConfig;
            config.ImageTrackingMode = TrackableImageFindingMode.ENABLE;
            NRSessionManager.Instance.SetConfiguration(config);
            Debug.Log(
                ">>> TrackingImageExampleController: Image Tracking enabled through Scan Button"
            );
        }

        /// <summary> Disables the image tracking. </summary>
        public void DisableImageTracking()
        {
            var config = NRSessionManager.Instance.NRSessionBehaviour.SessionConfig;
            config.ImageTrackingMode = TrackableImageFindingMode.DISABLE;
            NRSessionManager.Instance.SetConfiguration(config);
            Debug.Log(
                ">>> TrackingImageExampleController: Image Tracking disabled through 'X' Button of Scanning Mode"
            );
        }

        public void initImageTrackingSession()
        {
            // Get trackable images just for logging
            NRFrame.GetTrackables<NRTrackableImage>(
                m_TempTrackingImages,
                NRTrackableQueryFilter.All
            );
            Debug.Log(
                "Recognized images before init: " + m_TempTrackingImages.Count
            );
            NRSessionManager.Instance.InstantiateNewTrackableFactory();

            // Get trackable images just for logging
            NRFrame.GetTrackables<NRTrackableImage>(
                m_TempTrackingImages,
                NRTrackableQueryFilter.All
            );
            Debug.Log(
                "Recognized images after init: " + m_TempTrackingImages.Count
            );
        }
    }
}
