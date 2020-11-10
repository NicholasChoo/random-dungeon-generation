using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public float timeBetweenAttack;
    public float startTimeBetweenAttack;

    void Update()
    {
        if(timeBetweenAttack <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Attack();
                timeBetweenAttack = startTimeBetweenAttack;
            }
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
