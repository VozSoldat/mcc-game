// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class SwitchAcidity : MonoBehaviour
{
    public AnimatorOverrideController basicAcidController;

    AnimatorOverrideController currentAcidController;
    Animator animator;

    void Start()
    {
        this.currentAcidController = new AnimatorOverrideController(
            GetComponent<Animator>().runtimeAnimatorController
        );
        this.animator = GetComponent<Animator>();
        this.animator.runtimeAnimatorController = this.currentAcidController;
    }

    public void SwitchAcidityLevel(float acidityLevel)
    {
        if (acidityLevel < 0)
        {
            this.animator.runtimeAnimatorController = this.basicAcidController;
        }
        else
        {
            this.animator.runtimeAnimatorController = this.currentAcidController;
        }
    }
}
