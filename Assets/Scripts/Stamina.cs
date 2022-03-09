using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    private Coroutine StamCor;
    public int STR;

    public void StaminaSetup()
    {
        if(StamCor != null)
        {
            StopCoroutine(StamCor);
        }

        StamCor = StartCoroutine(StaminaTime(5f));
    }

    IEnumerator StaminaTime(float timer)
    {
        while (true)
        {
            timer  -= Time.deltaTime;
            STR = (int)timer;

            if(timer <= 0)
            {
                break;
            }
            yield return null;
        }
    }
}
