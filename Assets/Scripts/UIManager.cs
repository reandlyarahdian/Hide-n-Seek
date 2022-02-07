using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pointPanel;
    private List<TextMeshProUGUI> text = new List<TextMeshProUGUI>();
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject end;
    [SerializeField]
    private GameObject Leaderboard;
    [SerializeField]
    private TextMeshProUGUI Points;
    [SerializeField]
    private TextMeshProUGUI Timer;

    public GameObject catchbutton;

    private See see;

    private void Awake()
    {
        TextMeshProUGUI[] array = pointPanel.GetComponentsInChildren<TextMeshProUGUI>();
        for (int i = 0; i < array.Length; i++)
        {
            text.Add(array[i]);
        }
    }

    private void Start()
    {
        see = FindObjectOfType<See>();
    }

    public void CatchButton()
    {
        see.Catch();
    }

    public void LeaderBoard(int[] id, int[] points)
    {
        for(int i = 0; i < points.Length; i++)
        {
            TextMeshProUGUI textMesh =  Instantiate(Points, Leaderboard.transform);
            textMesh.text = $"Player {id[i] + 1}: {points[i]} Points";
        }
    }

    public void PointText(int index, int ID, int Point)
    {
        text[index].text = $"Player {ID} {Point}";
    }

    public void TimerText(float timer)
    {
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);

        Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void EndObj(bool isActive)
    {
        end.SetActive(isActive);
    }

    public void MenuObj(bool isActive)
    {
        menu.SetActive(isActive);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Paused()
    {
        GameManager.Instance.isPaused = !GameManager.Instance.isPaused;
        GameManager.Instance.PauseMenu(GameManager.Instance.isPaused);
    }
}
