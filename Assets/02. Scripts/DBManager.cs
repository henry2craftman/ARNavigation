using System.Collections.Generic;
using System.IO;
using UnityEngine;

// JsonUtility를 통해 JSON을 Object로 변환
public class DBManager : MonoBehaviour
{
    class POIDataList
    {
        public List<POIData> pois = new List<POIData>();
    }

    POIDataList data = new POIDataList();

    // Start is called before the first frame update
    void Start()
    {
        // Resources 폴더를 사용하지 않을 시
        //string path = Application.dataPath + "/04. Resources/ROIInfo.json";
        //string json = File.ReadAllText(path);
        //Debug.Log(json);

        // Resources 폴더를 사용 시
        TextAsset textAsset = Resources.Load<TextAsset>("ROIInfo");
        string json = textAsset.text;

        data = JsonUtility.FromJson<POIDataList>(json);
        foreach (POIData po in data.pois)
        {
            Debug.Log(po.name);
        }        
    }
}
