using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompassManager : MonoBehaviour
{
    public Image compassImg;
    public TMP_Text compassAngleTxt;
    public static float magneticHeading;
    public static float trueHeading;
    public float smoothingValue = 1;

    void Awake()
    {
        Input.location.Start(); //위치 서비스 시작

        // 나침반 기능 활성화
        Input.compass.enabled = true;
    }

    //void Update()
    //{
    //    // 나침반에서 현재 방향(각도) 가져오기
    //    float angle = Input.compass.trueHeading;

    //    // 목표 회전값 설정
    //    Quaternion targetRotation = Quaternion.Euler(0, 0, -angle);

    //    // 현재 회전값과 목표 회전값 사이를 부드럽게 보간
    //    compassImg.transform.rotation = targetRotation;

    //    // 텍스트 컴포넌트에 각도 표시 (소수점 없이)
    //    compassAngleTxt.text = Mathf.RoundToInt(angle).ToString() + "°";
    //}

    Quaternion targetRotation;
    IEnumerator Start()
    {
        while (true)
        {
            //헤딩 값 가져오기
            if (Input.compass.headingAccuracy >= 0)
            {
                magneticHeading = Input.compass.magneticHeading;
                trueHeading = Input.compass.trueHeading;
                targetRotation = Quaternion.Euler(0, 0, magneticHeading);
                compassAngleTxt.text = Mathf.RoundToInt(magneticHeading).ToString() + "°";
            }
            compassImg.transform.rotation = Quaternion.Lerp(compassImg.transform.rotation, targetRotation, smoothingValue * Time.deltaTime);

            yield return new WaitForSeconds(0.01f);
        }
    }
}
