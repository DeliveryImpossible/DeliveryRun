using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespwan : MonoBehaviour
{
    public Vector3 playerRespwanLocation;

    private void Update()
    {
        if(transform.position.y < -30)
        {
            transform.position = playerRespwanLocation;
        }
    }
}
