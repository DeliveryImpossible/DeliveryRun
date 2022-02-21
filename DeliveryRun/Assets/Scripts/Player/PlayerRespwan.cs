using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespwan : MonoBehaviour
{
    public Vector3 playerRespwanLocation;
    public int minPlayerY = -30;

    private void Update()
    {
        if(transform.position.y < minPlayerY)
        {
            transform.position = playerRespwanLocation;
        }
    }
}
