using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using TMPro;
using static System.Collections.Specialized.BitVector32;

public class CameraManager : MonoBehaviour
{
    ARSession arSession;
    ARCoreSessionSubsystem aRCoresessionSubsystem;
    ArRecordingConfig arRecordingConfig;

    public Camera cam;
    public TMP_Text log;
    string path = $"/storage/emulated/0/DCIM/ARNavigation/";

    private void Awake()
    {
        arSession = GetComponent<ARSession>();
        aRCoresessionSubsystem = (ARCoreSessionSubsystem)arSession.subsystem;
    }

    private void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Capture());
        }
    }

    public void TakePicture()
    {
        StartCoroutine(Capture());
    }
    
    public void StartRecord()
    {
        string fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".mp4";
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        ArSession session = aRCoresessionSubsystem.session;

        using (arRecordingConfig = new ArRecordingConfig())
        {
            arRecordingConfig.SetMp4DatasetFilePath(session, filePath);

            ArStatus status = aRCoresessionSubsystem.StartRecording(arRecordingConfig);
            print(status);
            log.text = arRecordingConfig.GetMp4DatasetFilePath(session);
        }
    }

    public void StopRecord()
    {
        ArStatus status = aRCoresessionSubsystem.StopRecording();
        log.text = status.ToString();
        print(status);
    }
    IEnumerator Capture()
    {
        yield return new WaitForEndOfFrame();

        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24); // RGBA 
        cam.targetTexture = rt;

        var currentRT = RenderTexture.active; // 현재 랜더링 되고 있는 텍스쳐
        RenderTexture.active = rt; // 활성 택스쳐

        cam.Render();

        Texture2D image = new Texture2D(Screen.width, Screen.height);
        image.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        image.Apply(); // 활성 택스쳐를 적용

        cam.targetTexture = null;

        RenderTexture.active = currentRT; // 초기화

        byte[] bytes = image.EncodeToPNG(); // 저장

        string fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllBytes(filePath, bytes);

        Destroy(rt);
        Destroy(image);
    }
}
