using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iDSetup : MonoBehaviour
{
    public int ID;
    public int Team;
    public void Setup(int id)
    {
        ID = id;
    }

    public int TeamSetup()
    {
        switch (ID)
        {
            case 1:
                return Team = 2;
            case 2:
                return Team = 2;
            case 3:
                return Team = 2;
            case 4:
                return Team = 1;
            case 5:
                return Team = 1;
            case 6:
                return Team = 1;
            default:
                return 0;
        }
    }
}
