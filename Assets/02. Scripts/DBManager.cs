using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    class POIDataList
    {
        public POIData[] pois = new POIData[2];
    }

    POIDataList data = new POIDataList();

    // Start is called before the first frame update
    void Start()
    {
        //string path = Application.dataPath + "04. Resources/ROIInfo.json";

        TextAsset json = Resources.Load<TextAsset>("ROIInfo");
        Debug.Log(json.text);

        data = JsonUtility.FromJson<POIDataList>(json.text);

        Debug.Log(data.pois.Length);
    }
}
