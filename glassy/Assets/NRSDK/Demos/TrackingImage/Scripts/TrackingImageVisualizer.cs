using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;
using UnityEngine.UI;

public class TrackingImageVisualizer : MonoBehaviour
{
    public NRTrackableImage Image;

    protected void DisableImageTracking()
    {
        var config = NRSessionManager.Instance.NRSessionBehaviour.SessionConfig;
        config.ImageTrackingMode = TrackableImageFindingMode.DISABLE;
        NRSessionManager.Instance.SetConfiguration(config);
        Debug.Log(
            ">>> TrackingImageVisualizer: Disabled Image Tracking after having recognized the plant!"
        );
    }
}
