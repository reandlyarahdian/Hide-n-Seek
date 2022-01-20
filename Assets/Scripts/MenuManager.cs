using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Mode(int i)
    {
        Passer.Instance.Mode(i);
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
