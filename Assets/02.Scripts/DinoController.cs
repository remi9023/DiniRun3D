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
        transform.position += Vector3.forward * Time.deltaTime * zMoveSpeed; // 매 프레임마다 객체를 +x 방향으로 1유닛씩 이동
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
}