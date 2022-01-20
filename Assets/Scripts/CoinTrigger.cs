using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hide") || other.gameObject.CompareTag("Seek"))
        {
            int iD = other.gameObject.GetComponent<iDSetup>().ID;
            GameManager.Instance.PointAdder(iD, 10);
            this.gameObject.SetActive(false);
        }
    }
}
