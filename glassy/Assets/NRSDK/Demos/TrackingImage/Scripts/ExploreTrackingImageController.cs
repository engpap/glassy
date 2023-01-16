using System.Collections.Generic;
using UnityEngine;

namespace NRKernal.NRExamples
{
    public class ExploreTrackingImageController : NRKernal.NRExamples.TrackingImageController
    {
        /// <summary> A prefab for visualizing an TrackingImage. </summary>

        public void Start()
        {
            Debug.Log(">>> ExploreTrackingImageController, Start()");
            base.initImageTrackingSession();
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
                    // If we are in explore mode, then the image is recognized and proper content shown.

                    ExploreTrackingImageVisualizer visualizer = (ExploreTrackingImageVisualizer)Instantiate(
                        TrackingImageVisualizerPrefab,
                        image.GetCenterPose().position,
                        image.GetCenterPose().rotation
                    );
                    visualizer.Image = image;
                    visualizer.transform.parent = transform;

                    visualizer.showContentBasedOnRecognizedImage();

                    Destroy(visualizer.gameObject);
                    Debug.Log(
                        ">>> ExploreTrackingImageController, Update(): in if; Destroyed Visualizer"
                    );
                }
            }
        }

        public void EnableImageTracking()
        {
            base.initImageTrackingSession();
            Debug.Log(
                ">>> ExploreTrackingImageController, EnableImageTracking(): Memory of tracked images cleared! Calling EnableImageTracking() parent method."
            );
            base.EnableImageTracking();
        }
    }
}
