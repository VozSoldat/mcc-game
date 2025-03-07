// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class SwitchAcidityAnimator : MonoBehaviour
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
        var parent = this.GetComponentInParent<AcidityController>();
        parent.OnAcidityChange.AddListener(this.SwitchAcidityLevel);
        this.SwitchAcidityLevel(parent.AcidityLevel);
    }

    public void SwitchAcidityLevel(float acidityLevel)
    {
        if (acidityLevel < 0)
        {
            this.animator.runtimeAnimatorController = this.basicAcidController;
        }
        else if (acidityLevel > 0)
        {
            this.animator.runtimeAnimatorController = this.currentAcidController;
        }
    }
}
