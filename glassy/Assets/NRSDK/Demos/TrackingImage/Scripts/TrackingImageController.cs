using System.Collections.Generic;
using UnityEngine;

namespace NRKernal.NRExamples
{
/// <summary> Controller for TrackingImage example. </summary>
public class TrackingImageController : MonoBehaviour
{
    /// <summary> A prefab for visualizing an TrackingImage. </summary>
    public TrackingImageVisualizer TrackingImageVisualizerPrefab;

    /// <summary> The visualizers. </summary>
    private Dictionary<int, TrackingImageVisualizer> m_Visualizers =
        new Dictionary<int, TrackingImageVisualizer>();

    /// <summary> The temporary tracking images. </summary>
    protected List<NRTrackableImage> m_TempTrackingImages = new List<NRTrackableImage>();

    /// <summary> Enables the image tracking. </summary>
    public void EnableImageTracking()
    {
        var config = NRSessionManager.Instance.NRSessionBehaviour.SessionConfig;
        config.ImageTrackingMode = TrackableImageFindingMode.ENABLE;
        NRSessionManager.Instance.SetConfiguration(config);
        Debug.Log(">>> TrackingImageExampleController: Image Tracking enabled through Scan Button");
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
        NRFrame.GetTrackables<NRTrackableImage>(m_TempTrackingImages, NRTrackableQueryFilter.All);
        Debug.Log(">>> initImageTrackingSession(), Recognized images before init: " + m_TempTrackingImages.Count);

        // Instantiate new TrackableFacotry in order to discard already tracked images
        NRSessionManager.Instance.InstantiateNewTrackableFactory();

        // Get trackable images just for logging
        NRFrame.GetTrackables<NRTrackableImage>(m_TempTrackingImages, NRTrackableQueryFilter.All);
        Debug.Log(">>> initImageTrackingSession(), Recognized images after init: " + m_TempTrackingImages.Count);
    }
}
}