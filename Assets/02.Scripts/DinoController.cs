using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float zMoveSpeed;
    public float xMoveSpeed;
    // ��ü�� �߽��̵���ġ
    public Vector3 sphereCenter;
    // ��ü�� ������
    public float sphereRadius = 0.5f;
    void Start()
    {
    }
    void Update()
    {
        DinoMove();
     
    }

        void DinoMove()
        {
            {
                // Z�����ΰ�Ӿ������̵�
                transform.position += Vector3.forward * Time.deltaTime * zMoveSpeed;
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Translate(-xMoveSpeed * Time.deltaTime, 0, 0);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Translate(xMoveSpeed * Time.deltaTime, 0, 0);
                }
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.9f, 3.9f), transform.position.y, transform.position.z);
            }


            void DoorCheck()
            {
                // ��ü ���� ����Collider���� ����
                Collider[] hitColliders = Physics.OverlapSphere(transform.position + sphereCenter, sphereRadius);
                // ������ Collider�� ó��
                foreach (Collider doors in hitColliders)
                {
                    Debug.Log("������ ������Ʈ: " + doors.gameObject.name);
                }
            }
            // ��ü ������ Gizmo�� �ð�ȭ
            void OnDrawGizmos()
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position + sphereCenter, sphereRadius);
            }
        }
    }

 