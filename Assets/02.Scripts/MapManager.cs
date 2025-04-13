using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    public GameObject[] mapPrefabs;
public GameObject goalObject; // 거리를 구하기 위한 오브젝트를 담기 위한 변수.
    public GameObject[] testMapPrefabs;
    public StageScriptableObject[] stages;

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

    void Start()
    {
        CreateStage();
        CtreatMap();
        CtreatTestMap();
        goalObject = GameObject.FindWithTag("Goal"); // Goal 오브젝트를 찾아서 대입해준다.
    }
    private void CreateStage()
    {
        int currentStageIndex = GetStage();
        currentStageIndex = currentStageIndex % stages.Length; // 이렇게 하면 stages의 범위를 벗어나는 경우가 없을 것이다.
        StageScriptableObject stage = stages[currentStageIndex];
        CtreatMap(stage.maps);
    }
    private void CtreatMap(Map[] stageMaps)
    {
        Vector3 mapPosition = Vector3.zero;
        for (int i = 0; i < stageMaps.Length; i++)
        {
            Map selectedMap = stageMaps[i]; // 만들 Map을 순서대로 선택한다.
            if (i > 0)
            {
                // 2번째 Map에서부터 이전의 Map의 크기의 반을 더해준다.
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2;
            }
            Map nowMap = Instantiate(selectedMap, mapPosition, Quaternion.identity, transform);
            mapPosition.z += nowMap.GetComponent<Map>().GetMapSize() / 2; //현재 선택된 Map의 길이의 반을 더한다.
        }
    }

    private void CtreatMap()
    {
        Vector3 mapPosition = Vector3.zero;
        for (int i = 0; i < 5; i++)
        {
            GameObject selectedMap; // 만들 Map을 선택한다.
            if (i > 0)
            {
                selectedMap = mapPrefabs[Random.Range(1, mapPrefabs.Length)]; ;
                // 2번째 Map에서부터 이전의 Map의 크기의 반을 더해준다.
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2;
            }
            else
            {
                selectedMap = mapPrefabs[0];
            }
            GameObject nowMap = Instantiate(selectedMap, mapPosition, Quaternion.identity);
            mapPosition.z += nowMap.GetComponent<Map>().GetMapSize() / 2; //현재 선택된 Map의 길이의 반을 더한다.
        }
    }
    private void CtreatTestMap()
    {
        Vector3 mapPosition = Vector3.zero;
        for (int i = 0; i < testMapPrefabs.Length; i++)
        {
            GameObject selectedMap = testMapPrefabs[i]; // 만들 Map을 순서대로 선택한다.
            if (i > 0)
            {
                // 2번째 Map에서부터 이전의 Map의 크기의 반을 더해준다.
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2;
            }
            GameObject nowMap = Instantiate(selectedMap, mapPosition, Quaternion.identity);
            mapPosition.z += nowMap.GetComponent<Map>().GetMapSize() / 2; //현재 선택된 Map의 길이의 반을 더한다.
        }
    }
    public float GetGoalDistance()
    {
        return goalObject.transform.position.z;
    }
    public int GetStage()
    {
        return PlayerPrefs.GetInt("Stage", 1);
    }
}
