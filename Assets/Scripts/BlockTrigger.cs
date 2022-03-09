using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTrigger : MonoBehaviour
{
    [SerializeField]
    private string enemyTag;
    private string teamTag;
    private Stamina stamina;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == teamTag)
        {
            other.gameObject.GetComponent<Stamina>().StaminaSetup();
        }
        else if(other.gameObject.tag == enemyTag)
        {

        }
    }
}
