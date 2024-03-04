#define UNITY_ANDROID

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using TMPro;
using UnityEngine.UI;


public class CameraManager : MonoBehaviour
{
    ARSession arSession;
    ARCoreSessionSubsystem aRCoresessionSubsystem;
    ArRecordingConfig arRecordingConfig;

    public int frameRate = 30;
    public Camera cam;
    public TMP_Text log;
    public Text txt;
    string galleryPath = $"/storage/emulated/0/DCIM/ARNavigation/";
    private int count;
    bool isTakingVideo;
    Texture2D image;
    Rect rect;


    private void Awake()
    {
        Application.targetFrameRate = frameRate;

        image = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);
        rect = new Rect(0, 0, Screen.width, Screen.height);

        arSession = FindAnyObjectByType<ARSession>();
        aRCoresessionSubsystem = (ARCoreSessionSubsystem)arSession.subsystem;
    }

    public void TakePicture()
    {
        if (!isTakingVideo)
        {
            StartCoroutine(Capture(false));
        }
    }

    public void TakeVideo()
    {
        isTakingVideo = !isTakingVideo;

        if(isTakingVideo)
            StartCoroutine(Capture(true));
    }
    
    // 작동하지 않음 확인 -> UIManager.cs의 StartRecord() 확인
    //public void StartRecordByARCore()
    //{
    //    string fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".mp4";
    //    string filePath = Path.Combine(Application.persistentDataPath, fileName);

    //    ArSession session = aRCoresessionSubsystem.session;

    //    using (arRecordingConfig = new ArRecordingConfig())
    //    {
    //        arRecordingConfig.SetMp4DatasetFilePath(session, filePath);

    //        ArStatus status = aRCoresessionSubsystem.StartRecording(arRecordingConfig);
    //        print(status);
    //        log.text = arRecordingConfig.GetMp4DatasetFilePath(session);
    //    }
    //}

    //public void StopRecordingByARCore()
    //{
    //    ArStatus status = aRCoresessionSubsystem.StopRecording();
    //    log.text = status.ToString();
    //    print(status);
    //}

    public void StopRecordingByFrame()
    {
        isTakingVideo = !isTakingVideo;
    }

    /// <summary>
    /// Capture Photo or Video
    /// </summary>
    /// <param name="mode"> 0: Photo, 1: Video</param>
    /// <returns></returns>
    WaitForEndOfFrame wait = new WaitForEndOfFrame();
    WaitForSeconds waitSec = new WaitForSeconds(0.016f);
    IEnumerator Capture(bool mode)
    {
        if(mode == false)
        {
            yield return wait;

            Execute();
        }
        else
        {
            while(isTakingVideo)
            {
                yield return waitSec;

                Execute();
            }
        }
    }
    void Execute()
    {
        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 32, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB); // RGBA 
        cam.targetTexture = rt;

        var currentRT = RenderTexture.active; // 현재 랜더링 되고 있는 텍스쳐
        RenderTexture.active = rt; // 활성 택스쳐

        cam.Render();

        //image = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);
        image.ReadPixels(rect, 0, 0);
        image.Apply(); // 활성 택스쳐를 적용

        cam.targetTexture = null;

        RenderTexture.active = currentRT; // 초기화

        byte[] bytes = image.EncodeToPNG(); // 저장

        string fileName = "/Images/" + String.Format("frame_{0:D4}", count++) + ".png";

        //string fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
        //string filePath = Path.Combine(Application.persistentDataPath, fileName); // Application.persistentDataPath 읽히지 않음

        string persistentPath = "C:\\Users\\User\\AppData\\LocalLow\\aaaaa\\ARNavi\\Demo";
#if UNITY_ANDROID
        //string persistentPath = "/storage/emulated/0/Android/data/com.aaaaa.ARNavi/files";
#elif UNITY_STANDALONE
        string persistentPath = "C:\\Users\\User\\AppData\\LocalLow\\aaaaa\\ARNavi\\Demo";
#endif
        string filePath = persistentPath + fileName;

        txt.text = filePath;
        File.WriteAllBytes(filePath, bytes);

        Destroy(rt);
        Destroy(image);
    }


}
