using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IconPositionCheck : MonoBehaviour
{
    void Update()
    {
        if(gameObject.transform.position.y > 41 || gameObject.transform.position.y < -48)
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        else
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
}
