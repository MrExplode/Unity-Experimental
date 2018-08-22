using System;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

    public float Speed = 10f;
    public float TurnSmoothing = 20f;

    private Rigidbody _rigdbody;
    private Animator _animator;
    private Vector3 _movement;

    private const float TOLERANCE = 0.01f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigdbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float inputVertical = Input.GetAxis("Vertical");
        float inputHorizontal = Input.GetAxis("Horizontal");

        Move(inputVertical, inputHorizontal);
        SetAnimation(inputVertical, inputHorizontal);

    }

    private void Move(float inputVertical, float inputHorizontal)
    {
        _movement.Set(inputVertical, 0, inputHorizontal);
        _movement = _movement.normalized * Speed * Time.deltaTime;
        _rigdbody.MovePosition(transform.position + _movement);

        if (Math.Abs(inputHorizontal) > TOLERANCE || Math.Abs(inputVertical) > TOLERANCE)
        {
            Rotate(inputHorizontal, inputVertical);
        }
    }

    private void Rotate(float inputVertical, float inputHorizontal)
    {
        var targetDirection = new Vector3(inputHorizontal, 0, inputVertical);
        var targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        var newRotation = Quaternion.Lerp(_rigdbody.rotation, targetRotation, Time.deltaTime * TurnSmoothing);

        _rigdbody.MoveRotation(newRotation);
    }

    private void SetAnimation(float inputVertical, float inputHorizontal)
    {
        var isRunning = Math.Abs(inputHorizontal) > TOLERANCE || Math.Abs(inputVertical) > TOLERANCE;

        _animator.SetBool("isRunning", isRunning);
    }
}
