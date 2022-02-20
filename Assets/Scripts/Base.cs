using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField]
    private string taging;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == taging)
        {
            StartCoroutine(playerHideTimer(other.gameObject));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == taging)
        {
            StopCoroutine(playerHideTimer(other.gameObject));
        }
    }

    IEnumerator playerHideTimer(GameObject game)
    {
        var chara = game.GetComponent<Hiding>();
        chara.hiding(taging);
        yield return new WaitForSeconds(3);
        chara.notHiding();
        yield return null;
    }
}
