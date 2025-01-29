using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputSO inputSO;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 2f;

    private Vector2 moveInput;
    private Vector2 lookInput;
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        inputSO.moveAction += OnMoveInput;
        inputSO.lookActin += OnLookInput;
    }
    
    private void OnDisable()
    {
        inputSO.moveAction -= OnMoveInput;
        inputSO.lookActin -= OnLookInput;
    }

    private void OnLookInput(Vector2 input)
    {
        lookInput = input;
    }

    private void OnMoveInput(Vector2 input)
    {
        moveInput = input;
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        characterController.Move(move * moveSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up * lookInput.x * rotationSpeed);
    }
}
