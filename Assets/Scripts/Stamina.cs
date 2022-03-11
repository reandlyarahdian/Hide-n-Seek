using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    private Coroutine StamCor;
    public float STR;
    [SerializeField]
    float STR0;

    private void Start()
    {
        STR0 = UnityEngine.Random.Range(1, STR);
        StamCor = StartCoroutine(StaminaTime());
    }

    public void StaminaSetup()
    {
        if(StamCor != null)
        {
            StopCoroutine(StamCor);
            STR0 = 10f;
            StamCor = StartCoroutine(StaminaTime());
        }
        
    }

    IEnumerator StaminaTime()
    {
        while (true)
        {
            STR0 -= Time.deltaTime;
            if(STR0 <= 0)
            {
                break;
            }
            yield return null;
        }
    }
}
