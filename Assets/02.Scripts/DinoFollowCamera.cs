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
            // ī�޶��� ���ο� ��ġ ��� (Dino�� �� ��� �������� Z�ุ ����)
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, target.position.z - offset.z);
            // ī�޶� ��ġ�� ������Ʈ
            transform.position = newPosition;
        }
    }
}
