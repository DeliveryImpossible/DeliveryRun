using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform pad;
    public Transform player;
    Vector3 moveForward;
    Vector3 moveRotate;
    static public float moveSpeed = 6f;
    public float rotateSpeed;

    private Animator animator;
    bool walking;

    public GameObject DeliverPanel;
    
    public float force;



    private void Awake(){
        animator = player.GetComponent<Animator>();
    }
    private void Start()
    {
        DeliverPanel.SetActive(false);
        animator.SetInteger("legs", 5);
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
            player.Translate(moveForward * moveSpeed * Time.deltaTime);
            
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
