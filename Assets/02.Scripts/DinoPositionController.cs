using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPositionController : MonoBehaviour
{
    public Transform raptors;
    public GameObject raptorPrefab; // �߰��� Raptor ������
    public int visibleRaptorNumber; // �����ְ� ���� Raptor�� ���� �Է�
    public float initialRadius = 0f; // ù ������Ʈ�� ������
    public float radiusGrowth = 0.12f; // ������Ʈ �� ������ ������
    public float angleIncrement = 137.508f; // ���� ���� ���� (���� ��� �ޱ� ���)

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
            if (i > visibleRaptorNumber - 1) // �����ְ� ���� ������ �Է¹���������Ʈ���� ũ�� ȭ�鿡 �Ⱥ��̰� �� (i�� 0���� ���۵ǹǷ� �Է¹��� ������ 1�� ����� �Ѵ�)
            {
                raptors.GetChild(i).gameObject.SetActive(false); // 10��° ������Ʈ���ʹ� ȭ�鿡 ������ �ʰ� ��
                continue; // �� �Ʒ��� ����� ���� �ʴ´� �� continue �Ʒ��� �ִ� �ڵ���� ������� �ʰ�, �ٷ� ���� ����(iteration)�� �Ѿ
            }
            else
            {
                if (raptors.childCount < visibleRaptorNumber) // �����ְ� ���� ������ �Է¹��� ������Ʈ������ ��ġ ������ ���
                {
                    // �������� ���� Ŀ�� �Ǻ���ġ ���� ȿ��
                    float currentRadius = initialRadius + (radiusGrowth * i);
                    // ������ ���� ���� (������Ʈ�� ��� ���������� ��������)
                    float angle = i * angleIncrement;
                    // ������ ���� ������ ��ȯ �� ��ǥ ���
                    float x = Mathf.Cos(angle * Mathf.Deg2Rad) * currentRadius;
                    float z = Mathf.Sin(angle * Mathf.Deg2Rad) * currentRadius;
                    // ��ġ ����
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
          