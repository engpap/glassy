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
    public class TrackingImageExampleController : MonoBehaviour
    {
        /// <summary> A prefab for visualizing an TrackingImage. </summary>
        public TrackingImageVisualizer TrackingImageVisualizerPrefab;

        /// <summary> The overlay containing the fit to scan user guide. </summary>
        //public GameObject FitToScanOverlay;

        /// <summary> The visualizers. </summary>
        private Dictionary<int, TrackingImageVisualizer> m_Visualizers =
            new Dictionary<int, TrackingImageVisualizer>();

        /// <summary> The temporary tracking images. </summary>
        private List<NRTrackableImage> m_TempTrackingImages = new List<NRTrackableImage>();

        private Dictionary<int, bool> hasAlreadyBeenRecognized = new Dictionary<int, bool>();

        public void Start()
        {
            Debug.Log("Start Example Controller");
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
                    if (hasAlreadyBeenRecognized[image.GetDataBaseIndex()] == false)
                    {
                        TrackingImageVisualizer visualizer = (TrackingImageVisualizer)Instantiate(
                            TrackingImageVisualizerPrefab,
                            image.GetCenterPose().position,
                            image.GetCenterPose().rotation
                        );
                        visualizer.Image = image;
                        visualizer.transform.parent = transform;
                        Debug.Log(
                            ">>> TrackingImageExampleController, Update(): Created new Visualizer!"
                        );

                        hasAlreadyBeenRecognized[image.GetDataBaseIndex()] =
                            visualizer.incrementCounter();

                        Destroy(visualizer.gameObject);
                        Debug.Log(
                            ">>> TrackingImageExampleController, Update(): in if; Destroyed Visualizer"
                        );
                    }
                    else
                    {
                        Debug.Log(
                            ">>> TrackingImageExampleController, Update(): Image already recognized!"
                        );
                    }
                }
            }
        }

        /// <summary> Enables the image tracking. </summary>
        public void EnableImageTracking()
        {
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
    }
}
