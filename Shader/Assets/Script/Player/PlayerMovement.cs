using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    private float _Speed = 2f;
    private Vector3 _MoveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            _MoveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
            _MoveDirection = _MoveDirection * _Speed;
        }

        _MoveDirection.y -= 10f * Time.deltaTime;

        characterController.Move(_MoveDirection * Time.deltaTime);
    }
}
