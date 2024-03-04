using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// Image Library의 각 이미지에 맞는 3D 오브젝트를 Resources 폴더에서 불러와 생성한다.
/// </summary>
[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageDetection : MonoBehaviour
{
    ARTrackedImageManager imageManager;
    List<GameObject> objs = new List<GameObject>();

    void Awake()
    {
        imageManager = GetComponent<ARTrackedImageManager>();

        imageManager.trackedImagesChanged += OnImageTrackedEvent;
    }

    /// <summary>
    /// 이미지가 변경되면 실행되는 이벤트 함수
    /// </summary>
    /// <param name="arg">이벤트를 위한 인자</param>
    void OnImageTrackedEvent(ARTrackedImagesChangedEventArgs arg)
    {
        foreach(ARTrackedImage trackedImage in arg.added)
        {
            string imageName = trackedImage.referenceImage.name;

            GameObject prefab = Resources.Load<GameObject>(imageName);

            if(prefab != null)
            {
                GameObject obj = Instantiate(prefab, trackedImage.transform.position, trackedImage.transform.rotation);
                obj.name = imageName;
                obj.transform.SetParent(trackedImage.transform);
                objs.Add(obj);
            }
        }

        foreach(ARTrackedImage trackedImage in arg.updated)
        {
            if(trackedImage.transform.childCount > 0)
            {
                trackedImage.transform.GetChild(0).position = trackedImage.transform.position;
                trackedImage.transform.GetChild(0).rotation = trackedImage.transform.rotation;
                trackedImage.transform.GetChild(0).gameObject.SetActive(true);
            }

            if (trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Limited)
            {
                string imageName = trackedImage.referenceImage.name;

                print(objs.Find(x => x.name == imageName));

                GameObject obj = objs.Find(x => x.name == imageName);

                obj.SetActive(false);

            }
        }

        foreach (ARTrackedImage trackedImage in arg.removed)
        {
            print(trackedImage.transform.childCount);
            if (trackedImage.transform.childCount > 0)
            {
                trackedImage.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnImageTrackedEvent;
    }
}
