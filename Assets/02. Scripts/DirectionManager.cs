using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using static System.Net.WebRequestMethods;

/// <summary>
/// Naver Cloud Platform의 Maps API중 Directions5 API에 Directions5 JSON 요청
/// </summary> 
public class DirectionManager : MonoBehaviour
{
    [SerializeField] string baseUrl = "https://naveropenapi.apigw.ntruss.com/map-direction/v1/driving";
    string clientID = "";
    string clientSecret = "";
    string myPoint = "126.741717,37.714491";
    string destination = "126.744259,37.712257";

    [Serializable]
    enum OptionCode
    {
        trafast,
        tracomfort,
        traoptimal,
        traavoidtoll,
        traavoidcaronly
    }
    [SerializeField] OptionCode optionCode = OptionCode.trafast;

    IEnumerator Start()
    {
        //string apiRequestURL = "https://naveropenapi.apigw.ntruss.com/map-direction/v1/driving?start=127.1058342,37.359708&goal=129.075986,35.179470&option=trafast";
        string apiRequestURL = baseUrl + $"?start={myPoint}&goal={destination}&option=trafast";

        UnityWebRequest request = UnityWebRequest.Get(apiRequestURL);
        request.SetRequestHeader("X-NCP-APIGW-API-KEY-ID", clientID);
        request.SetRequestHeader("X-NCP-APIGW-API-KEY", clientSecret);

        yield return request.SendWebRequest();

        switch (request.result)
        {
            case UnityWebRequest.Result.Success:
                break;
            case UnityWebRequest.Result.ConnectionError:
                yield break;
                break;
            case UnityWebRequest.Result.ProtocolError:
                yield break;
                break;
            case UnityWebRequest.Result.DataProcessingError:
                yield break;
                break;
        }

        if(request.isDone)
        {
            string json = request.downloadHandler.text;

            print(json);
        }
    }
}
