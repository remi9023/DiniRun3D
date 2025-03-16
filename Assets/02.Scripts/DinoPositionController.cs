using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPositionController : MonoBehaviour
{
    public Transform raptors;
    
    public float radius = 1f; // 원의 반지름
    public float ratio = 0.1f; // 배치 간격 비율 (작을수록 촘촘)
    void Update()
    {
        SetDinoPosition();
    }
    private void SetDinoPosition()
    {
        // 360도 각도 계산을 위한 각도 증가값
        float angleStep = 360f / (raptors.childCount * ratio);
        for (int i = 0; i < raptors.childCount; i++)
        {
            // 각 오브젝트의 배치 각도 계산
            float angle = i * angleStep;
            // 각도를 라디안으로 변환
            float angleRad = angle * Mathf.Deg2Rad; // degree 를 radian으로 치환
            // X와 Z 좌표를 원형으로 계산
            float x = Mathf.Cos(angleRad) * radius;
            float z = Mathf.Sin(angleRad) * radius;
            // 새로운 위치로 자식 오브젝트를 위치시킴
            raptors.GetChild(i).localPosition = new Vector3(x, 0, z);
        }
    }
}
          