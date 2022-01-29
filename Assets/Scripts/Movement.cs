using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f, turnSpeed = 2f, SmoothTurn =  0.01f;
    [SerializeField]
    private Transform cam;
    [SerializeField]
    private bool isSeek;

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
        if (isSeek)
        {
            Seek(freeLook);
        }
        cam = Camera.main.transform;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 input = new Vector3(CrossPlatformInputManager.GetAxis("Vertical"), 0, CrossPlatformInputManager.GetAxis("Horizontal")).normalized;
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

    void Seek(CinemachineVirtualCamera virtualCamera)
    {
        virtualCamera.AddCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(0, 0.5f, 0);
        CinemachinePOV cinemachine = virtualCamera.AddCinemachineComponent<CinemachinePOV>();
        cinemachine.m_HorizontalRecentering.m_RecenteringTime = 0.5f;
        cinemachine.m_HorizontalRecentering.m_enabled = true;
        cinemachine.m_HorizontalRecentering.m_WaitTime = 0.5f;
        cinemachine.m_VerticalRecentering.m_RecenteringTime = 0.5f;
        cinemachine.m_VerticalRecentering.m_enabled = true;
        cinemachine.m_VerticalRecentering.m_WaitTime = 0.5f;
        cinemachine.m_VerticalAxis.m_InputAxisName = "Mouse Y";
        cinemachine.m_HorizontalAxis.m_InputAxisName = "Mouse X";
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
