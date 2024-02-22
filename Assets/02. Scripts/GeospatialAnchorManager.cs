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
    GameObject anchoredAsset;
    public float latitude = 33;
    public float longtitude = 126;
    public float altitude = 70;
    public Text logTxt;

    // Start is called before the first frame update
    void Start()
    {
        logTxt.text = "시작";

        earthManager = GetComponent<AREarthManager>();
        anchorManager = GetComponent<ARAnchorManager>();
    }

    public void SetAnchor()
    {
        if (earthManager.EarthTrackingState == TrackingState.Tracking)
        {
            string log = "";
            Vector3 cameraPos = new Vector3((float)earthManager.CameraGeospatialPose.Latitude,
                                            (float)earthManager.CameraGeospatialPose.Longitude,
                                            (float)earthManager.CameraGeospatialPose.Altitude);
            log += $"Camera GeoPose: {cameraPos.x},{cameraPos.y},{cameraPos.z}\n";
            log += $"Camera VirtualPose: {transform.position}\n";

            var anchor =
                anchorManager.AddAnchor(
                    latitude,
                    longtitude,
                    altitude,
                    Quaternion.identity);
            anchoredAsset = Instantiate(anchorPrefab, anchor.transform);
            
            Vector3 anchorPos = new Vector3(latitude, longtitude, altitude);
            log += $"{anchoredAsset.name} GeoPose: {latitude},{longtitude},{altitude}\n";
            log += $"{anchoredAsset.name} VirtualPose: {anchoredAsset.transform.position}\n";

            float distance = Mathf.Sqrt(Mathf.Pow(cameraPos.x - latitude, 2) + Mathf.Pow(cameraPos.y - longtitude, 2));
            log += $"{distance * 100000}m";
            logTxt.text = log;
        }
    }
    public void ResetAnchor()
    {
        if(anchoredAsset != null)
        {
            anchoredAsset.transform.SetParent(this.transform);
            anchoredAsset.transform.localPosition = Vector3.zero + transform.forward;
        }
    }
}