using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPositionController : MonoBehaviour
{
    public Transform raptors;
    public GameObject raptorPrefab; // �߰��� Raptor ������

    public float radius = 1f; // ���� ������
    public float ratio = 0.1f; // ��ġ ���� ���� (�������� ����)
    void Update()
    {
        SetDinoPosition();
    }
    private void SetDinoPosition()
    {
        for (int i = 0; i < raptors.childCount; i++)
        {
            if (i > 8) // Raptor������Ʈ�� 10��°���ʹ� ȭ�鿡 �������� �ʰ� �� (i�� 0���� ���۵ǹǷ� 9�� 10��°�̴�.)
            {
                raptors.GetChild(i).gameObject.SetActive(false); // 10��° ������Ʈ���ʹ� ȭ�鿡 ������ �ʰ� ��
                continue; // �� �Ʒ��� ����� ���� �ʴ´� �� continue �Ʒ��� �ִ� �ڵ���� ������� �ʰ�, �ٷ� ���� ������ �Ѿ
            }
            else // Raptor�� ������ 9�� ������ ���� ���� ����ؼ� ��ġ����
            {
                if (raptors.childCount < 10) // 9���� ������Ʈ������ ��ġ ������ ���
                {
                    // 360�� ���� ����� ���� ���� ������
                    float angleStep = 360f / (raptors.childCount * ratio);
                    // �� ������Ʈ�� ��ġ ���� ���
                    float angle = i * angleStep;
                    // ������ �������� ��ȯ
                    float angleRad = angle * Mathf.Deg2Rad;
                    // X�� Z ��ǥ�� �������� ���
                    float x = Mathf.Cos(angleRad) * radius;
                    float z = Mathf.Sin(angleRad) * radius;
                    // ���ο� ��ġ�� �ڽ� ������Ʈ�� ��ġ��Ŵ
                    raptors.GetChild(i).localPosition = new Vector3(x, 0, z);
                }
            }
        }
    }
    public void SetDoorCalc(DoorType doorType, int doorNumber)
    {
        if (doorType.Equals(DoorType.Plus)) // ���ϱ�
        {
            PlusRaptor(doorNumber);
        }
        else if (doorType.Equals(DoorType.Minus)) // ����
        {
            MinusRaptor(doorNumber);
        }
        else if (doorType.Equals(DoorType.Times)) // ���ϱ�
        {
            int raptorNum = (raptors.childCount * (doorNumber - 1));
            PlusRaptor(raptorNum);
        }
        else if (doorType.Equals(DoorType.Division)) // ������
        {
            int raptorNum = raptors.childCount - (raptors.childCount / doorNumber);
            MinusRaptor(raptorNum);
        }
    }
    private void PlusRaptor(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(raptorPrefab, raptors); //�Ű������� ���� number ����ŭ raptorPrefab�� �������� �ݴϴ�.
        }
    }
    private void MinusRaptor(int number)
    {
        // ���� ���ڰ� ���� ���� Raptor���ں��� �� ũ��
        if (number > raptors.childCount)
        {
            // ���� ���ڸ� ���� ���� Raptor���� �������ش�. ( ������ 0�� �� ���̹Ƿ� , ���߿� 0�� �Ǹ� ���ӿ��� ��ų ���� )
            number = raptors.childCount;
        }
        int raptorNum = raptors.childCount; // ���� ���� Raptor���ڸ� ���ϰ�
                                            // �� ������ Raptor������Ʈ���� �����ؼ� ��ü Raptor���� ���� �����ִ� ���ڸ�ŭ �� ������ ���ų� Ŭ�� ���� ���� i�� ���̸鼭
        for (int i = raptorNum - 1; i >= (raptorNum - number); i--)
        {
            Destroy(raptors.GetChild(i).gameObject); // �� ������ ������Ʈ���� ���� ��ŵ�ϴ�.
        }
    }
}
          