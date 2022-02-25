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

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        moniterLight = moniter.transform.GetChild(0).GetComponent<Light>();
    }

    public void FindAnimationEvent(int index)
    {
        if(index == 0)
        {
            line.GetComponent<RectTransform>().anchoredPosition = new Vector3(line.GetComponent<RectTransform>().anchoredPosition.x, 100); ;
        }
        else if(index == 1)
        {
            ChangeCameraPosition(tv);
        }
        else if(index == 2)
        {
            line.GetComponent<RectTransform>().anchoredPosition = new Vector3(line.GetComponent<RectTransform>().anchoredPosition.x, 50);
            ChangeCameraPosition(outside_full);
            mainCamera.transform.rotation = Quaternion.Euler(10, 0, 0);
        }
        else if(index == 3)
        {
            ChangeCameraPosition(outside_in);
        }
        else if(index == 5)
        {
            Debug.Log(playerAnim.GetInteger("legs"));
            Debug.Log(playerAnim.GetInteger("arms"));
            playerAnim.SetInteger("legs", 5);
            playerAnim.SetInteger("arms", 17); 
            Debug.Log(playerAnim.GetInteger("legs"));
            Debug.Log(playerAnim.GetInteger("arms"));
            ChangeCameraPosition(home);
            mainCamera.transform.rotation = Quaternion.Euler(10, 180, 0);
        }
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
