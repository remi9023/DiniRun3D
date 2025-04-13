using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DinoController : MonoBehaviour
{
    public DinoPositionController dinoPositionController;
    public float zMoveSpeed;        // 앞으로 가는 속도
    public float xMoveSpeed;        // 좌우 이동 속도
    public static DinoController instance;
    public bool isGameStart;
    public Vector3 sphereCenter;    // 감지 구체의 중심 위치 (상대좌표)
    public float sphereRadius = 0.5f; // 구체의 반지름

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Update()
    {
        if (GameManager.instance.isGameStart.Equals(true))
        {
            DinoMove();
            DoorCheck();
        }
    }

    // 공룡 이동 처리
    void DinoMove()
    {
        // 앞으로 계속 전진
        transform.position += Vector3.forward * Time.deltaTime * zMoveSpeed;

        // 좌우 이동
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-xMoveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(xMoveSpeed * Time.deltaTime, 0, 0);
        }

        // 좌우 이동 제한 (범위 밖으로 못 나가게)
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.9f, 3.9f), transform.position.y, transform.position.z);
    }

    // 문(또는 오브젝트) 감지 처리
    void DoorCheck()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + sphereCenter, sphereRadius);

        foreach (Collider doors in hitColliders)
        {
            if (doors.CompareTag("Goal")) // Tag가 Gaol인 오브젝트면
            {
                Debug.Log("골인이야!!"); // 골인이야 라는 로그를 출력
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") + 1); // 현재 Stage에서 1 더하고 저장 (다음 스테이지의 숫자를 저장하는 것)
                doors.gameObject.GetComponent<BoxCollider>().enabled = false; // door의 BoxCollider 비활성화
                SceneManager.LoadScene(0); // 0번 씬(현재 씬)을 로드

            }
            else
            {
                // 여기에서 충돌한 Door의 타입과 문에 써진 숫자를 받아와서
                int doorNumber = doors.gameObject.GetComponent<SelectDoors>().GetDoorNumber(transform.position.x);
                DoorType doorType = doors.gameObject.GetComponent<SelectDoors>().GetDoorType(transform.position.x);
                doors.gameObject.GetComponent<BoxCollider>().enabled = false; // door의 BoxCollider 비활성화
                                                                              // DinoPositionController스크립트에서 적절하게 사칙연산에 맞게 계산해야 함.
                dinoPositionController.SetDoorCalc(doorType, doorNumber);
            }

        }
    }

    // 감지 범위를 씬 뷰에서 시각적으로 표시
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + sphereCenter, sphereRadius);
    }
}
