using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform pad;
    public GameObject DeliverPanel;
    public float force;
    public float rotateSpeed;
    public float moveSpeed;

    public static bool walking;

    Vector3 moveForward;
    Vector3 moveRotate;
    private Transform player;
    private Animator animator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = player.GetChild(0).GetComponent<Animator>();
        DeliverPanel.SetActive(false);
        animator.SetInteger("legs", 5);
        InGameSave.SetSpeed(moveSpeed);
        walking = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        transform.localPosition = 
            Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position, pad.rect.width * 0.3f); 

        moveForward = new Vector3(0, 0, transform.localPosition.y).normalized; // player 이동 방향
        moveRotate = new Vector3(0, transform.localPosition.x, 0).normalized; // player 회전 방향

        if(!walking){ 
            walking = true;
            animator.SetInteger("legs", 1);
            animator.SetInteger("arms", 1);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 조이스틱 원위치
        transform.localPosition = Vector3.zero; 
        moveForward = Vector3.zero;
        moveRotate = Vector3.zero;

        StopCoroutine("PlayerMove");

        walking = false;
        animator.SetInteger("legs", 5);
        animator.SetInteger("arms", 5);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine("PlayerMove");
    }

    IEnumerator PlayerMove(){
        while(true){
            // 이동
            player.Translate(moveForward * InGameSave.GetSpeed() * Time.deltaTime);
            
            // 회전
            if(Mathf.Abs(transform.localPosition.x) > pad.rect.width * 0.2f){
                player.Rotate(moveRotate * rotateSpeed * Time.deltaTime);
            }

            yield return null;
        }
    }

    public void OpenDeliverPanel()
    {
        DeliverPanel.SetActive(true);
    }

}
