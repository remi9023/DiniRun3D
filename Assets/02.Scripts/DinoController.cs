using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float zMoveSpeed;
    public float xMoveSpeed;
    void Start()
    {
    }
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * zMoveSpeed;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-xMoveSpeed * Time.deltaTime, 0, 0); // �� �����Ӹ��� ��ü�� +x �������� 1���־� �̵�
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(xMoveSpeed * Time.deltaTime, 0, 0);
        }
    }
}