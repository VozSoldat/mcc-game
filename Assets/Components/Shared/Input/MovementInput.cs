using UnityEngine;

public class MovementInput : MonoBehaviour
{
    Animator animator;

    public Vector3 InputDirection
    {
        get => inputDirection;
        set => inputDirection = value;
    }
    private Vector3 inputDirection;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal > 0)
        {
            animator.SetBool("facingRight", true);
            Debug.Log("facingRight");
            var scale = animator.transform.localScale;
            animator.transform.localScale = new Vector3(Mathf.Abs(scale.x), scale.y, scale.z);
        }
        else if (horizontal < 0)
        {
            animator.SetBool("facingRight", false);
            var scale = animator.transform.localScale;
            animator.transform.localScale = new Vector3(-Mathf.Abs(scale.x), scale.y, scale.z);
        }

        if (vertical > 0)
        {
            animator.SetBool("flyUp", true);
            animator.SetBool("flyDown", false);
        }
        else if (vertical < 0)
        {
            animator.SetBool("flyDown", true);
            animator.SetBool("flyUp", false);
        }
        else
        {
            animator.SetBool("flyUp", false);
            animator.SetBool("flyDown", false);
        }

        inputDirection = new Vector3(horizontal, 0, vertical).normalized;
    }
}
