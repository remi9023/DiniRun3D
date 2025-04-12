using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float zMoveSpeed;
    public float xMoveSpeed;
    // 구체의 중심이될위치
    public Vector3 sphereCenter;
    // 구체의 반지름
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
                // Z축으로계속앞으로이동
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
                // 구체 영역 내의Collider들을 감지
                Collider[] hitColliders = Physics.OverlapSphere(transform.position + sphereCenter, sphereRadius);
                // 감지된 Collider들 처리
                foreach (Collider doors in hitColliders)
                {
                    Debug.Log("감지된 오브젝트: " + doors.gameObject.name);
                }
            }
            // 구체 영역을 Gizmo로 시각화
            void OnDrawGizmos()
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position + sphereCenter, sphereRadius);
            }
        }
    }

 