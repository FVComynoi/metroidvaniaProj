using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    #region Animation Variables
    PlayerAnimController playerAnimController;
    SpriteRenderer spriteRenderer;
    #endregion
    #region Movement Variables
    [SerializeField] float moveSpeed = 5f, jumpForce = 10f;
    private InputSystem_Actions inputSystemActions;
    private InputAction move, attack, jump;
    private float inputDirectionX => inputSystemActions.Player.Move.ReadValue<Vector2>().x;
    private bool isJumpPressed => inputSystemActions.Player.Jump.WasPressedThisFrame();
    Rigidbody2D rb;
    private GroundChecker groundChecker;
    #endregion
    private void Awake()
    {
        playerAnimController = GetComponent<PlayerAnimController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        groundChecker = GetComponentInChildren<GroundChecker>();
        inputSystemActions = new InputSystem_Actions();
        inputSystemActions.Enable();
        rb = GetComponent<Rigidbody2D>();
        /*move = inputSystemActions.Player.Move;
        jump = inputSystemActions.Player.Jump;
        attack = inputSystemActions.Player.Attack;*/
    }
    void Update()
    {
        CheckMovementForAnim();
        CheckJumping();
    }
    private void CheckMovementForAnim()
    {
        /*if (inputDirectionX != 0)
 {
     playerAnimController.SetIsMovingParam(true);
 }
 else
 {
     playerAnimController.SetIsMovingParam(false);
 }
 ^A mesma coisa do que essa linha embaixo^*/
        playerAnimController.SetIsMovingParam(inputDirectionX!=0f); 
        FlipSprite();
    }
    void FlipSprite()
    {
        if (inputDirectionX > 0)
            spriteRenderer.flipX = false;
        else if  (inputDirectionX < 0)
            spriteRenderer.flipX = true;
    }
    void FixedUpdate()
    {
        //Vector3 moveDirection = new Vector2(inputDirectionX, 0f);
        rb.linearVelocityX = inputDirectionX * moveSpeed;
    }

    void CheckJumping()
    {
        if(isJumpPressed && groundChecker.IsGrounded())
            rb.linearVelocityY = jumpForce;
    }
}
