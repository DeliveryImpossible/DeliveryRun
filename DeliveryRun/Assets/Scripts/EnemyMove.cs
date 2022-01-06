using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float movespeed;
    private int direction = -1; 
    float originalPosition; 
    

    private Animator animator;
    private float time = 0;


    void Start(){
        animator = GetComponent<Animator>();
        animator.SetInteger("legs", 1);
        animator.SetInteger("arms", 1);
        
        originalPosition = transform.position.x;
    }

    void Update(){
        transform.position += new Vector3(movespeed * Time.deltaTime * direction, 0, 0);
        checkTime();
    }


    private void checkTime(){
        time += Time.deltaTime;
        if(time >= 12f){
            RotateEnemy();
            time = 0;
        }
    }

    private void RotateEnemy(){ 
        direction *= -1;
        transform.Rotate(0, 180, 0);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Player"){
            Destroy(gameObject);
        }
    }
    
}
