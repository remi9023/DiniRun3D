using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoFollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    void Start()
    {
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            // 카메라의 새로운 위치 계산 (Dino가 좌 우로 움직여도 Z축만 따라감)
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, target.position.z - offset.z);
            // 카메라 위치를 업데이트
            transform.position = newPosition;
        }
    }
}
