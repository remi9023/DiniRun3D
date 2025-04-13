using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI nowStageText;
    public TextMeshProUGUI nextStageText;
    public static GameManager instance;
    public bool isGameStart;
    public GameObject titlePanel;
    public GameObject gamePanel;
    public Slider progressBar;
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
        Time.timeScale = 0f; // 게임 전체 시간을 잠깐 멈춤
        progressBar.value = 0f;
        titlePanel.SetActive(true); // Title Panel은 활성화
        gamePanel.SetActive(false); // GamePanel은 비활성화
        nowStageText.text = MapManager.instance.GetStage().ToString();
        nextStageText.text = (MapManager.instance.GetStage() + 1).ToString();
    }
    void Update()
    {
        SetDistanceProgressBar();
    }
    public void SetDistanceProgressBar() // 프로그레스바를 세팅하기 위한 함수
    {
        if (isGameStart.Equals(false)) // 게임이 시작하기 전에는 실행되지 않게 한다
        {
            return;
        }
        // 전체 거리중 Dino의 위치 거리 비율
        float goalDistance = DinoController.instance.transform.position.z / MapManager.instance.GetGoalDistance();
        progressBar.value = goalDistance;
    }
    public void GameStart()
    {
        Debug.Log("게임 시작");
        isGameStart = true;
        Time.timeScale = 1f; // 게임 전체 시간을 원래대로 흐르게 함.
        titlePanel.SetActive(false); // Title Panel은 비활성화
        gamePanel.SetActive(true); // GamePanel은 활성화
    }
}
