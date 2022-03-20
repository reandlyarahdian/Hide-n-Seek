using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    [HideInInspector]
    public bool inPlayer;
    [SerializeField]
    private float speed;
    private Vector3 vector;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("A")) inPlayer = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("A")) inPlayer = false;
    }

    public void MoveBall(Vector3 target)
    {
        vector = target;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(vector);
    }
}
