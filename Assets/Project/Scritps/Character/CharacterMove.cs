using System;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

    public CharacterSettings settings;

    private AudioSource _audioSource;
    private Rigidbody _rigdbody;
    private Animator _animator;
    private Vector3 _movement;

    private const float TOLERANCE = 0.01f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _rigdbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float inputVertical = Input.GetAxis("Vertical");
        float inputHorizontal = Input.GetAxis("Horizontal");

        Move(inputVertical, inputHorizontal);
        SetAnimation(inputVertical, inputHorizontal);
        SetAudio(inputVertical, inputHorizontal);
    }

    private void SetAudio(float inputVertical, float inputHorizontal)
    {
        if (Math.Abs(inputHorizontal) > TOLERANCE || Math.Abs(inputVertical) > TOLERANCE)
        {
            if (!_audioSource.isPlaying)
                _audioSource.Play();
        } else
        {
            if (_audioSource.isPlaying)
                _audioSource.Stop();
        }
    }

    private void Move(float inputVertical, float inputHorizontal)
    {
        _movement.Set(inputVertical, 0, inputHorizontal);
        _movement = _movement.normalized * settings.Speed * Time.deltaTime;
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
        var newRotation = Quaternion.Lerp(_rigdbody.rotation, targetRotation, Time.deltaTime * settings.TurnSmoothing);

        _rigdbody.MoveRotation(newRotation);
    }

    private void SetAnimation(float inputVertical, float inputHorizontal)
    {
        var isRunning = Math.Abs(inputHorizontal) > TOLERANCE || Math.Abs(inputVertical) > TOLERANCE;

        _animator.SetBool("isRunning", isRunning);
    }
}
