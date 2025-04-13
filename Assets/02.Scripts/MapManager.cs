using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    public GameObject[] mapPrefabs;
public GameObject goalObject; // �Ÿ��� ���ϱ� ���� ������Ʈ�� ��� ���� ����.
    public GameObject[] testMapPrefabs;

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
        CtreatMap();
        CtreatTestMap();
        goalObject = GameObject.FindWithTag("Goal"); // Goal ������Ʈ�� ã�Ƽ� �������ش�.
    }
    private void CtreatMap()
    {
        Vector3 mapPosition = Vector3.zero;
        for (int i = 0; i < 5; i++)
        {
            GameObject selectedMap; // ���� Map�� �����Ѵ�.
            if (i > 0)
            {
                selectedMap = mapPrefabs[Random.Range(1, mapPrefabs.Length)]; ;
                // 2��° Map�������� ������ Map�� ũ���� ���� �����ش�.
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2;
            }
            else
            {
                selectedMap = mapPrefabs[0];
            }
            GameObject nowMap = Instantiate(selectedMap, mapPosition, Quaternion.identity);
            mapPosition.z += nowMap.GetComponent<Map>().GetMapSize() / 2; //���� ���õ� Map�� ������ ���� ���Ѵ�.
        }
    }
    private void CtreatTestMap()
    {
        Vector3 mapPosition = Vector3.zero;
        for (int i = 0; i < testMapPrefabs.Length; i++)
        {
            GameObject selectedMap = testMapPrefabs[i]; // ���� Map�� ������� �����Ѵ�.
            if (i > 0)
            {
                // 2��° Map�������� ������ Map�� ũ���� ���� �����ش�.
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2;
            }
            GameObject nowMap = Instantiate(selectedMap, mapPosition, Quaternion.identity);
            mapPosition.z += nowMap.GetComponent<Map>().GetMapSize() / 2; //���� ���õ� Map�� ������ ���� ���Ѵ�.
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
