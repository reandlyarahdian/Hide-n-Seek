using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Passer : GenericSingletonClass<Passer>
{
    public Mode mode;

    public void Setting()
    {
        GameManager.Instance.mode = mode;
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
