using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RotateCam : MonoBehaviour
{
    public float turnSpeed = 0.05f;
    private float xRotate = 0.0f;

    CinemachineVirtualCamera cmvc;
    CinemachineComposer aim;
    UiActiveController uiAC;
    private void Start()
    {
        cmvc = transform.GetChild(0).GetComponent<CinemachineVirtualCamera>();
        aim = cmvc.GetCinemachineComponent<CinemachineComposer>();
        uiAC = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UiActiveController>();
    }

    public void SetAimY()
    {
        aim.m_ScreenY = (float)0.5;
    }
    void Update()
    {
        if (!(Input.mousePosition.x < Screen.width / 2 || 
            (Input.mousePosition.y < Screen.height / 100 * 40 && Input.mousePosition.x > Screen.width / 4 * 3)) 
            && Input.mousePosition.x < Screen.width / 100 * 85 )
        {
            if (Input.GetMouseButton(0) && !Joystick.walking && uiAC.isStart)
            {
                float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
                xRotate = Mathf.Clamp(xRotate + xRotateSize, (float)-0.5, (float)1.5);
            }

            aim.m_ScreenY = xRotate;
        }
    }
}