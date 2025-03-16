using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPositionController : MonoBehaviour
{
    public Transform raptors;
    
    public float radius = 1f; // ���� ������
    public float ratio = 0.1f; // ��ġ ���� ���� (�������� ����)
    void Update()
    {
        SetDinoPosition();
    }
    private void SetDinoPosition()
    {
        // 360�� ���� ����� ���� ���� ������
        float angleStep = 360f / (raptors.childCount * ratio);
        for (int i = 0; i < raptors.childCount; i++)
        {
            // �� ������Ʈ�� ��ġ ���� ���
            float angle = i * angleStep;
            // ������ �������� ��ȯ
            float angleRad = angle * Mathf.Deg2Rad; // degree �� radian���� ġȯ
            // X�� Z ��ǥ�� �������� ���
            float x = Mathf.Cos(angleRad) * radius;
            float z = Mathf.Sin(angleRad) * radius;
            // ���ο� ��ġ�� �ڽ� ������Ʈ�� ��ġ��Ŵ
            raptors.GetChild(i).localPosition = new Vector3(x, 0, z);
        }
    }
}
          