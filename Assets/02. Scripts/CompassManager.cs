using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompassManager : MonoBehaviour
{
    public Image compassImg;
    public TMP_Text compassAngleTxt;
    public float smoothSpeed = 0.1f; // ȸ���� �ε巯���� �����ϴ� �ӵ�

    void Start()
    {
        // ��ħ�� ��� Ȱ��ȭ
        Input.compass.enabled = true;
    }

    void Update()
    {
        // ��ħ�ݿ��� ���� ����(����) ��������
        float angle = Input.compass.trueHeading;

        // ��ǥ ȸ���� ����
        Quaternion targetRotation = Quaternion.Euler(0, 0, -angle);

        // ���� ȸ������ ��ǥ ȸ���� ���̸� �ε巴�� ����
        compassImg.transform.rotation = Quaternion.Lerp(compassImg.transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);

        // �ؽ�Ʈ ������Ʈ�� ���� ǥ�� (�Ҽ��� ����)
        compassAngleTxt.text = Mathf.RoundToInt(angle).ToString() + "��";
    }
}
