using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueAnimations : MonoBehaviour
{
    private int t = 0;

    public GameObject line;
    public GameObject moniter;
    public Material moniter_on;
    public Material moniter_off;
    public Animator playerAnim;

    private GameObject mainCamera;
    private Light moniterLight;

    private Vector3 home = new Vector3((float)-6.2, (float)1.2, (float)25);
    private Vector3 tv = new Vector3((float)-7.1, (float)1.2, (float)23);
    private Vector3 outside_full = new Vector3((float)150, (float)12, (float)-30);
    private Vector3 outside_in = new Vector3((float)150, (float)1, (float)-5);
    private Quaternion homeRotation = Quaternion.Euler(10, 180, 0);
    private Quaternion outRotation = Quaternion.Euler(10, 0, 0);

    private int existNameLineY = 50;
    private int noneNameLineY = 100;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        moniterLight = moniter.transform.GetChild(0).GetComponent<Light>();
    }

    public void FindAnimationEvent(int index)
    {
        if(index == 0)
        {
            ChangeLineYPositionDependingOnName(existNameLineY);
        }
        else if(index == 1)
        {
            ChangeCameraPosition(tv);
        }
        else if(index == 2)
        {
            ChangeLineYPositionDependingOnName(noneNameLineY);
            ChangeCameraPosition(outside_full, outRotation);
        }
        else if(index == 3)
        {
            ChangeCameraPosition(outside_in);
        }
        else if(index == 5)
        {
            playerAnim.SetInteger("legs", 5);
            playerAnim.SetInteger("arms", 17); 
            ChangeCameraPosition(home, homeRotation);
        }
    }

    private void ChangeLineYPositionDependingOnName(int y)
    {
        line.GetComponent<RectTransform>().anchoredPosition = 
            new Vector3(line.GetComponent<RectTransform>().anchoredPosition.x, y);
    }

    private void ChangeCameraPosition(Vector3 vector, Quaternion quaternion)
    {
        mainCamera.transform.position = vector;
        mainCamera.transform.rotation = quaternion;
    }

    private void ChangeCameraPosition(Vector3 vector)
    {
        mainCamera.transform.position = vector;
    }

    private void Update()
    {
        t++;
        if(t > 100)
        {
            moniter.GetComponent<MeshRenderer>().materials[1].color = moniter_off.color;
            t = 0;
        }
        else if(t > 50)
        {
            moniter.GetComponent<MeshRenderer>().materials[1].color = moniter_on.color;
        }
        moniterLight.intensity = t / 50;
    }

}
