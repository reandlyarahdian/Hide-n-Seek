using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f, turnSpeed = 2f, SmoothTurn =  0.01f;
    [SerializeField]
    private Transform cam;

    Rigidbody rb;

    float refVelocity;
    float smoothInputMagnitude;
    float angle;
    Vector3 velocity;

    private void Awake()
    {
        CinemachineVirtualCamera freeLook = FindObjectOfType<CinemachineVirtualCamera>();
        freeLook.Follow = transform;
        freeLook.LookAt = transform;
        cam = Camera.main.transform;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal")).normalized;
        float InputMagintude = input.magnitude;
        smoothInputMagnitude = Mathf.SmoothDamp(smoothInputMagnitude, InputMagintude, ref refVelocity, SmoothTurn);

        AngelCalc(input, InputMagintude);

        velocity = transform.forward * speed * smoothInputMagnitude;
    }

    private void FixedUpdate()
    {
        Rotation(angle);
        Move(velocity);
    }

    void AngelCalc(Vector3 input, float InputMagnitude)
    {
        float targetAngle = Mathf.Atan2(input.z, input.x) * Mathf.Rad2Deg + cam.eulerAngles.y;
        angle = Mathf.LerpAngle(angle, targetAngle, turnSpeed * InputMagnitude * Time.deltaTime);
    }

    void Move(Vector3 velocity)
    {
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }

    void Rotation(float angle)
    {
        rb.MoveRotation(Quaternion.Euler(Vector3.up * angle));
    }
}
