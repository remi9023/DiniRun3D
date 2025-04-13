using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{

    public GameObject[] mapPrefabs;

    void Start()
    {
        Vector3 mapPosition = Vector3.zero; // �ʱ� ���� ��ġ�� �������� �Ѵ�.
        for (int i = 0; i < 10; i++) // �ϴ� �׽�Ʈ�� 
        {
            GameObject selectedMap;// ���� Map�� �����Ѵ�.
            if (i > 0)
            {
                selectedMap = mapPrefabs[Random.Range(1, mapPrefabs.Length)]; ;
                // 2��° Map�������� ������ Map�� ũ���� ���� �����ش�.
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2;
            }
            else
            {
                selectedMap = mapPrefabs[0]; // ó������ ������ 0��° �迭�� Map�� ���������.
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
