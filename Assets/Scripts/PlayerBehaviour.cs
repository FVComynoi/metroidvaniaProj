using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    InputSystem_Actions inputSystemActions;
    private InputAction move, attack;
    Rigidbody rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        move = inputSystemActions.Player.Move;
    }
    private void OnEnable()
    {
        move.Enable();
    }
    private void OnDisable()
    {
        move.Disable();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
