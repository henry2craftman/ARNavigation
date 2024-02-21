using Google.XR.ARCoreExtensions;
using Google.XR.ARCoreExtensions.GeospatialCreator.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using CesiumForUnity;

public class GeospatialAnchorManager : MonoBehaviour
{
    public GameObject anchorPrefab;
    AREarthManager earthManager;
    ARAnchorManager anchorManager;
    public float latitude = 33;
    public float longtitude = 126;
    public float altitude = 70;
    public Text logTxt;

    // Start is called before the first frame update
    void Awake()
    {
        logTxt.text += "시작\n";

        earthManager = GetComponent<AREarthManager>();
        anchorManager = GetComponent<ARAnchorManager>();
    }

    public void SetAnchor()
    {
        logTxt.text += "시작\n";

        if (earthManager.EarthTrackingState == TrackingState.Tracking)
        {
            var anchor =
                anchorManager.AddAnchor(
                    latitude,
                    longtitude,
                    altitude,
                    Quaternion.identity);
            var anchoredAsset = Instantiate(anchorPrefab, anchor.transform);
            logTxt.text += "배치완료: " + anchoredAsset.transform.name + "\n";
        }
    }
}