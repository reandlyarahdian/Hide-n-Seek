using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public GameObject Single, Team, GameA, GameB, Mode;
    public Button AI, Seek, Hide, TeamA, TeamB, Back, SingleBTN, TeamBTN, Base2an, Boy2an;

    public void OpenSingle()
    {
        Single.SetActive(true);

        Mode.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(AI.gameObject);
    }

    public void OpenTeam()
    {
        Team.SetActive(true);

        Mode.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(TeamA.gameObject);
    }

    public void OpenMode()
    {
        Single.SetActive(false);
        Team.SetActive(false);
        Mode.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(SingleBTN.gameObject);
    }

    public void OpenGameA()
    {
        Single.SetActive(false);
        GameA.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(Base2an.gameObject);
    }
    public void OpenGameB()
    {
        Single.SetActive(false);
        GameB.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(Boy2an.gameObject);
    }


    public void ModeA(int i)
    {
        Passer.Instance.Mode(i);
    }

    public void ModeB(int i)
    {
        Passer.Instance.Team(i);
    }

    public void SceneGame(int i)
    {
        SceneManager.LoadScene(i);
        Time.timeScale = 1f;
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
