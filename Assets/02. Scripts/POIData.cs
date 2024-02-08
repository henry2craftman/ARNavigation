using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct POIData
{
    private string name;
    private string description;
    private float latitude;
    private float longitude;
    private float altitude;

    public POIData(string name, string description, float latitude, float longtitude, float altitude)
    {
        this.name = name;
        this.description = description;
        this.latitude = latitude;
        this.longitude = longtitude;
        this.altitude = altitude;
    }
}
