using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DinoController : MonoBehaviour
{
    public DinoPositionController dinoPositionController;
    public float zMoveSpeed;        // ������ ���� �ӵ�
    public float xMoveSpeed;        // �¿� �̵� �ӵ�
    public static DinoController instance;
    public bool isGameStart;
    public Vector3 sphereCenter;    // ���� ��ü�� �߽� ��ġ (�����ǥ)
    public float sphereRadius = 0.5f; // ��ü�� ������

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

    // ���� �̵� ó��
    void DinoMove()
    {
        // ������ ��� ����
        transform.position += Vector3.forward * Time.deltaTime * zMoveSpeed;

        // �¿� �̵�
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-xMoveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(xMoveSpeed * Time.deltaTime, 0, 0);
        }

        // �¿� �̵� ���� (���� ������ �� ������)
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.9f, 3.9f), transform.position.y, transform.position.z);
    }

    // ��(�Ǵ� ������Ʈ) ���� ó��
    void DoorCheck()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + sphereCenter, sphereRadius);

        foreach (Collider doors in hitColliders)
        {
            if (doors.CompareTag("Goal")) // Tag�� Gaol�� ������Ʈ��
            {
                Debug.Log("�����̾�!!"); // �����̾� ��� �α׸� ���
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") + 1); // ���� Stage���� 1 ���ϰ� ���� (���� ���������� ���ڸ� �����ϴ� ��)
                doors.gameObject.GetComponent<BoxCollider>().enabled = false; // door�� BoxCollider ��Ȱ��ȭ
                SceneManager.LoadScene(0); // 0�� ��(���� ��)�� �ε�

            }
            else
            {
                // ���⿡�� �浹�� Door�� Ÿ�԰� ���� ���� ���ڸ� �޾ƿͼ�
                int doorNumber = doors.gameObject.GetComponent<SelectDoors>().GetDoorNumber(transform.position.x);
                DoorType doorType = doors.gameObject.GetComponent<SelectDoors>().GetDoorType(transform.position.x);
                doors.gameObject.GetComponent<BoxCollider>().enabled = false; // door�� BoxCollider ��Ȱ��ȭ
                                                                              // DinoPositionController��ũ��Ʈ���� �����ϰ� ��Ģ���꿡 �°� ����ؾ� ��.
                dinoPositionController.SetDoorCalc(doorType, doorNumber);
            }

        }
    }

    // ���� ������ �� �信�� �ð������� ǥ��
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + sphereCenter, sphereRadius);
    }
}
