using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> text = new List<TextMeshProUGUI>();
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject end;
    [SerializeField]
    private GameObject Leaderboard;
    [SerializeField]
    private TextMeshProUGUI Points;

    private void Awake()
    {
        TextMeshProUGUI[] array = GetComponentsInChildren<TextMeshProUGUI>();
        for (int i = 0; i < array.Length; i++)
        {
            text.Add(array[i]);
        }
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

    public void TimerText(int index, float timer)
    {
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);

        text[index].text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void EndObj(bool isActive)
    {
        end.SetActive(isActive);
    }

    public void MenuObj(bool isActive)
    {
        menu.SetActive(isActive);
    }
}
