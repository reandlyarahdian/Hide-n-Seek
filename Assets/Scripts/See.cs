using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class See : MonoBehaviour
{
    private UIManager uI;
    [SerializeField]
    private GameObject game;
    private SphereCollider sphere;

    private void Start()
    {
        uI = FindObjectOfType<UIManager>();
        sphere = GetComponentInChildren<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Seek") && this.gameObject.CompareTag("Hide"))
        {
            GameManager.Instance.PointAdder(1, 100);
            this.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Hide") && this.gameObject.CompareTag("Seek"))
        {
            uI.catchbutton.SetActive(true);
            game = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Hide") && this.gameObject.CompareTag("Seek"))
        {
            uI.catchbutton.SetActive(false);
            game = null;
        }
    }

    public void Catch()
    {
        GameManager.Instance.PointAdder(1, 100);
        game.SetActive(false);
    }
}
