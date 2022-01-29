using Cinemachine;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TouchInput : MonoBehaviour
{
    public float TouchSensitivityX = 1f;
    public float TouchSensitivityY = 1f;

    public string TouchXInputMapTo = "Mouse X";
    public string TouchYInputMapTo = "Mouse Y";

    void Start()
    {
        CinemachineCore.GetInputAxis = GetInputAxis;
    }

    private float GetInputAxis(string axisName)
    {
        if (Input.touchCount > 0)
        {
            if (axisName == TouchXInputMapTo)
                return CrossPlatformInputManager.GetAxis(TouchXInputMapTo) * TouchSensitivityX;
            if (axisName == TouchYInputMapTo)
                return CrossPlatformInputManager.GetAxis(TouchYInputMapTo) * TouchSensitivityY;
        }
        return CrossPlatformInputManager.GetAxis(axisName);
    }
}