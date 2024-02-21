using Google.XR.ARCoreExtensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Collections;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using static System.Collections.Specialized.BitVector32;

public class UIManager : MonoBehaviour
{
    ARSession arSsession;
    ARCameraManager cameraManager;
    public Text logTxt;
    bool isPaused = false;

    // Start is called before the first frame update
    void Awake()
    {
        arSsession = FindAnyObjectByType<ARSession>();
        gameObject.AddComponent<ARRecordingManager>();
        cameraManager = FindAnyObjectByType<ARCameraManager>();
    }

    ArSession session;
    public void StartRecording()
    {
        string path = $"/storage/emulated/0/DCIM/ARNavigation/arcore-session-{DateTime.Now:yyyyMMddHHmmss}.mp4";

        try
        {
            if (arSsession.subsystem is ARCoreSessionSubsystem subsystem)
            {
                session = subsystem.session;

                if (subsystem.recordingStatus == ArRecordingStatus.Ok)
                    return;

                using (var config = new ArRecordingConfig(session))
                {
                    config.SetMp4DatasetFilePath(session, path);
                    config.SetRecordingRotation(session, 90);
                    //config.SetRecordingRotation(session, GetRotation());
                    var status = subsystem.StartRecording(config);
                    logTxt.text = ($"Recording Started. {status}");
                    logTxt.color = Color.red;
                }
            }
        }
        catch (Exception e)
        {
            logTxt.text = e.Message;
        }
    }

    public void StopRecording()
    {
        StartCoroutine(StopRecordingCoroutine());
    }

    IEnumerator StopRecordingCoroutine()
    {
        if (arSsession.subsystem is ARCoreSessionSubsystem subsystem)
        {
            logTxt.text = ($" 확인중 {subsystem.recordingStatus}");

            yield return new WaitUntil(() => subsystem.recordingStatus == ArRecordingStatus.Ok);

            session.StopRecording();

            logTxt.text = ($"Recording Done. {subsystem.recordingStatus}");
            logTxt.color = Color.green;

            yield return new WaitForSeconds(2);

            using (var configurations = cameraManager.GetConfigurations(Allocator.Temp))
            {
                // There are two ways to enumerate the camera configurations.

                // 1. Use a foreach to iterate over all the available configurations
                foreach (var config in configurations)
                {
                    logTxt.text = $"{config.width}x{config.height}{(config.framerate.HasValue ? $" at {config.framerate.Value} Hz" : "")}{(config.depthSensorSupported == Supported.Supported ? " depth sensor" : "")}";
                }
            }
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            if (arSsession.subsystem is ARCoreSessionSubsystem subsystem)
            {
                session = subsystem.session;

                using (var config = new ArRecordingConfig(session))
                {
                    config.SetAutoStopOnPause(session, isPaused);
                }
            }
        }
    }
}
