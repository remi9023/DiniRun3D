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
        Time.timeScale = 0f; // ���� ��ü �ð��� ��� ����
        progressBar.value = 0f;
        titlePanel.SetActive(true); // Title Panel�� Ȱ��ȭ
        gamePanel.SetActive(false); // GamePanel�� ��Ȱ��ȭ
        nowStageText.text = MapManager.instance.GetStage().ToString();
        nextStageText.text = (MapManager.instance.GetStage() + 1).ToString();
    }
    void Update()
    {
        SetDistanceProgressBar();
    }
    public void SetDistanceProgressBar() // ���α׷����ٸ� �����ϱ� ���� �Լ�
    {
        if (isGameStart.Equals(false)) // ������ �����ϱ� ������ ������� �ʰ� �Ѵ�
        {
            return;
        }
        // ��ü �Ÿ��� Dino�� ��ġ �Ÿ� ����
        float goalDistance = DinoController.instance.transform.position.z / MapManager.instance.GetGoalDistance();
        progressBar.value = goalDistance;
    }
    public void GameStart()
    {
        Debug.Log("���� ����");
        isGameStart = true;
        Time.timeScale = 1f; // ���� ��ü �ð��� ������� �帣�� ��.
        titlePanel.SetActive(false); // Title Panel�� ��Ȱ��ȭ
        gamePanel.SetActive(true); // GamePanel�� Ȱ��ȭ
    }
}
