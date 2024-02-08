using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompassManager : MonoBehaviour
{
    public Image compassImg;
    public TMP_Text compassAngleTxt;
    public float smoothSpeed = 0.1f; // 회전의 부드러움을 조절하는 속도

    void Start()
    {
        // 나침반 기능 활성화
        Input.compass.enabled = true;
    }

    void Update()
    {
        // 나침반에서 현재 방향(각도) 가져오기
        float angle = Input.compass.trueHeading;

        // 목표 회전값 설정
        Quaternion targetRotation = Quaternion.Euler(0, 0, -angle);

        // 현재 회전값과 목표 회전값 사이를 부드럽게 보간
        compassImg.transform.rotation = Quaternion.Lerp(compassImg.transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);

        // 텍스트 컴포넌트에 각도 표시 (소수점 없이)
        compassAngleTxt.text = Mathf.RoundToInt(angle).ToString() + "°";
    }
}
