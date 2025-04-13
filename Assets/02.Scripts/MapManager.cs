using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{

    public GameObject[] mapPrefabs;

    void Start()
    {
        Vector3 mapPosition = Vector3.zero; // 초기 생성 위치는 원점으로 한다.
        for (int i = 0; i < 10; i++) // 일단 테스트로 
        {
            GameObject selectedMap;// 만들 Map을 선택한다.
            if (i > 0)
            {
                selectedMap = mapPrefabs[Random.Range(1, mapPrefabs.Length)]; ;
                // 2번째 Map에서부터 이전의 Map의 크기의 반을 더해준다.
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2;
            }
            else
            {
                selectedMap = mapPrefabs[0]; // 처음에는 무조건 0번째 배열의 Map이 만들어진다.
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
