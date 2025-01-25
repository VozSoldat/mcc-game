using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatInput : MonoBehaviour
{
    Animator animator;

    private bool basicAttack = false;
    public bool BasicAttack
    {
        get => basicAttack;
        set => basicAttack = value;
    }
    public bool isShooting = false;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            // BasicAttack = true;
            isShooting = true;
            if (Input.GetButtonDown("Fire1"))
            {
                // BasicAttack = true;
                animator.SetBool("isShooting", true);
            }
        }
        else
        {
            // BasicAttack = false;
            isShooting = false;
            if (Input.GetButtonUp("Fire1"))
            {
                animator.SetBool("isShooting", false);
            }
        }
        // else{
        //     BasicAttack = false;
        // }

        // Debug.Log("Basic Attack: " + BasicAttack);
    }
}
