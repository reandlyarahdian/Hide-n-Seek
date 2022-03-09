using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Passer : GenericSingletonClass<Passer>
{
    public Mode mode;
    public Team team;

    public void Setting()
    {
        GameManager.Instance.mode = mode;
        GameManager.Instance.team = team;
    }

    public void Team(int i)
    {
        switch (i)
        {
            case 0:
                team = global::Team.TeamA;
                break;
            case 1:
                team = global::Team.TeamB;
                break;
            default:
                break;
        }
    }

    public void Mode(int i)
    {
        switch (i)
        {
            case 1:
                mode = global::Mode.AI;
                break;
            case 2:
                mode = global::Mode.PlayerHide;
                break;
            case 3:
                mode = global::Mode.PlayerSeek;
                break;
            default:
                break;
        }
    }
}
