using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    #region Animatio Variables
    PlayerAnimController playerAnimController;
    SpriteRenderer spriteRenderer;
    #endregion
    #region Movement Variables
    [SerializeField] float moveSpeed = 5f, jumpForce;
    private InputSystem_Actions inputSystemActions;
    private InputAction move, attack, jump;
    private float inputDirectionX => inputSystemActions.Player.Move.ReadValue<Vector2>().x;
    Rigidbody rb;
    #endregion
    private void Awake()
    {
        playerAnimController = GetComponent<PlayerAnimController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        inputSystemActions = new InputSystem_Actions();
        inputSystemActions.Enable();
        rb = GetComponent<Rigidbody>();
        /*move = inputSystemActions.Player.Move;
        jump = inputSystemActions.Player.Jump;
        attack = inputSystemActions.Player.Attack;*/
    }
    void Update()
    {
        CheckMovementForAnim();
        Vector2 moveDirection = new Vector2(inputDirectionX, 0f);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
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
        {
            spriteRenderer.flipX = false;
        }
        else if  (inputDirectionX < 0)
            spriteRenderer.flipX = true;
    }
    void FixedUpdate()
    {
        //rb.AddForce(jumpForce);
    }
    private void OnEnable()
    {
        //move.Enable();
    }
    private void OnDisable()
    {
        //move.Disable();
    }
}
