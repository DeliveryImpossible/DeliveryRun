using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneAnimatorController : MonoBehaviour
{
    private Animator animator;
    int[] legs = {1,5};
    int[] arms = {9,10,16,17};

    private void Awake(){
        animator = GetComponent<Animator>();
        
    }
    void Start()
    {
        StartCoroutine(updateData());
    }

    IEnumerator updateData(){
        while(true){
            int leg = Random.Range(0,legs.Length);
            int arm = Random.Range(0, arms.Length);
            animator.SetInteger("legs", legs[leg]);
            animator.SetInteger("arms", arms[arm]);
            yield return new WaitForSeconds(2.0f);
        }
    }
}
