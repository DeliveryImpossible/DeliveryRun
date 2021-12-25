using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultAnimation : MonoBehaviour
{
    private Animator animator;
    private int[] legs = { 1, 5 };
    private int[] arms;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StartAnim(bool result)
    {
        bool win = result;
        if (win)
            arms = new int[] { 5, 17 };
        else
            arms = new int[] { 5, 6 };
        StartCoroutine(UpdateData());
    }

    IEnumerator UpdateData()
    {
        while (true)
        {
            int leg = Random.Range(0, legs.Length);
            animator.SetInteger("legs", legs[leg]);
            int arm = Random.Range(0, arms.Length);
            animator.SetInteger("arms", arms[arm]);

            yield return new WaitForSeconds(1.0f);
        }
    }
}
