using System;
using UnityEngine;
public class PlayerAnimController : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetIsMovingParam(bool isMoving)
    {
        animator.SetBool("IsMoving", isMoving);
    }
}
