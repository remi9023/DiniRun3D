using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{

    public GameObject[] mapPrefabs;

    void Start()
    {
        Vector3 mapPosition = Vector3.zero; // �ʱ� ���� ��ġ�� �������� �Ѵ�.
        for (int i = 0; i < 5; i++) // �ϴ� �׽�Ʈ�� 5���� ������.
        {
            GameObject selectedMap = mapPrefabs[Random.Range(0, mapPrefabs.Length)]; // ���� Map�� �������� �����Ѵ�.
            if (i > 0)
            {
                // 2��° Map�������� ������ Map�� ũ���� ���� �����ش�.
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2;
            }
            GameObject nowMap = Instantiate(selectedMap, mapPosition, Quaternion.identity); // ���� ���� ���� �����Ѵ�.
            mapPosition.z += nowMap.GetComponent<Map>().GetMapSize() / 2; //���� ������ Map�� ������ ���� ���Ѵ�.
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
