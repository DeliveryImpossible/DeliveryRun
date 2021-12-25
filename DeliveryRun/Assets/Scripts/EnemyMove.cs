using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public static float maxRange = 3f, minRange = 3f;
    public float movespeed;
    private int direction = -1; 
    float originalPosition; 
    

    private Animator animator;
    private int angle;


    void Start(){
        animator = GetComponent<Animator>();
        animator.SetInteger("legs", 1);
        animator.SetInteger("arms", 1);
        
        originalPosition = transform.position.x;
    }

    void Update(){
        transform.position += new Vector3(movespeed * Time.deltaTime * direction, 0, 0);
        CheckRotateRange(transform.position.x);
    }

    private void CheckRotateRange(float enemyposition){ 
            if(enemyposition >= originalPosition + maxRange || enemyposition <= originalPosition - minRange){
                RotateEnemy();
            }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Player"){
            RotateEnemy();
        }
    }

    private void RotateEnemy(){ // 반대 방향으로 이동
        direction *= -1;
        transform.Rotate(0, 180, 0);
    }
    
}
