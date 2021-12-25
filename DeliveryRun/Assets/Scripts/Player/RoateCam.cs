﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoateCam : MonoBehaviour
{
    public float turnSpeed = 4.0f; // 마우스 회전 속도
    private float xRotate = 0.0f;
    //private float yRotate = 0.0f;

    void Update()
    {
        if (Input.mousePosition.x > Screen.width / 2 && Input.mousePosition.x < Screen.width / 100 * 90)
        {
            if (Input.GetMouseButton(0))
            {
                //좌우
                /*float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
                yRotate = Mathf.Clamp(yRotate + yRotateSize, -40, 80);*/

                // 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
                float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
                // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
                // Clamp 는 값의 범위를 제한하는 함수
                xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);
            }


            // 카메라 회전량을 카메라에 반영(X, Y축만 회전)
            transform.eulerAngles = new Vector3(xRotate, transform.eulerAngles.y, 0);
        }
    }
}