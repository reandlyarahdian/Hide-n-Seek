using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockyTrigger : MonoBehaviour
{
    [SerializeField]
    private string taging, enemyTaging;

    int Team(string taging)
    {
        switch (taging)
        {
            case "A":
                return 1;
            case "B":
                return 2;
            default: 
                return -1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == taging)
        {
            other.gameObject.GetComponent<Stamina>().StaminaSetup();
        }
        else if(other.tag == enemyTaging)
        {
            GameManager.Instance.PointTeamAdder(Team(enemyTaging), 1);
        }
    }
}
