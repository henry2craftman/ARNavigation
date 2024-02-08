﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;

public class GPSManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI latitudeText;
    [SerializeField] TextMeshProUGUI longtitudeText;
    [SerializeField] TextMeshProUGUI debugText;
    private const float MaxWaitTime = 10f;
    private const float ResendTime = 1f;
    private const string GpsAccessFailed = "GPS access failed";
    private const string GpsInitFailed = "GPS initialization failed";
    private const string ResponseTimeout = "Response timeout";
    
    public POIData data = new POIData("제물포시장", "ABC", 1,1,1);

    private void Start()
    {
        StartCoroutine(TurnOnGPS());
    }

    IEnumerator TurnOnGPS()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            while (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                yield return null;
            }
        }

        if (!Input.location.isEnabledByUser)
        {
            UpdateGpsText(GpsAccessFailed, GpsAccessFailed);
            yield break;
        }

        Input.location.Start();

        float waitTime = 0;
        while (Input.location.status == LocationServiceStatus.Initializing && waitTime < MaxWaitTime)
        {
            yield return new WaitForSeconds(1);
            waitTime++;
        }

        if (Input.location.status == LocationServiceStatus.Failed || waitTime >= MaxWaitTime)
        {
            UpdateGpsText(GpsInitFailed, GpsInitFailed);
            yield break;
        }

        // 위치 정보를 반복적으로 업데이트
        while (Input.location.status == LocationServiceStatus.Running)
        {
            UpdateGpsData();
            yield return new WaitForSeconds(ResendTime);
        }
    }

    private void UpdateGpsData()
    {
        LocationInfo gps = Input.location.lastData;
        UpdateGpsText("Latitude: " + gps.latitude.ToString(), "Longtitude: " + gps.longitude.ToString());
    }

    private void UpdateGpsText(string latitude, string longtitude)
    {
        latitudeText.text = latitude;
        longtitudeText.text = longtitude;
    }
}