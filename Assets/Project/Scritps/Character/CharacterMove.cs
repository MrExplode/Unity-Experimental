using System;
using UnityEngine;
using UnityEngine.Networking;

public class CharacterMove : NetworkBehaviour {

    public CharacterSettings settings;

    private AudioSource _audioSource;
    private Rigidbody _rigdbody;
    private Animator _animator;
    private Vector3 _movement;

    private const float TOLERANCE = 0.01f;
    private int _idleNum = 2;

    [SyncVar]                                                                                                                                                                                                                                                               
    private bool _isMoving;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _rigdbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            float inputVertical = Input.GetAxis("Vertical");
            float inputHorizontal = Input.GetAxis("Horizontal");

            CmdSetIsMoving(inputVertical, inputHorizontal);
            Move(inputVertical, inputHorizontal);
        }
        SetAnimation();
        SetAudio();
    }

    [Command]
    private void CmdSetIsMoving(float inputVertical, float inputHorizontal)
    {
        _isMoving = Math.Abs(inputHorizontal) > TOLERANCE || Math.Abs(inputVertical) > TOLERANCE;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            //Damage!!
            _animator.SetTrigger("Damage");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            _animator.ResetTrigger("Damage");
        }
    }

    private void Move(float inputVertical, float inputHorizontal)
    {
        _movement.Set(inputVertical, 0, inputHorizontal);
        _movement = _movement.normalized * settings.Speed * Time.deltaTime;
        _rigdbody.MovePosition(transform.position + _movement);

        if (_isMoving)
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

    private void SetAnimation()
    {
        _animator.SetBool("isRunning", _isMoving);
        if (!_isMoving)
        {
            _animator.SetInteger("IdleNum", _idleNum);
        } else
        {
            _idleNum = new System.Random().Next(5);
        }
    }

    private void SetAudio()
    {
        if (_isMoving)
        {
            if (!_audioSource.isPlaying)
                _audioSource.Play();
        }
        else
        {
            if (_audioSource.isPlaying)
                _audioSource.Stop();
        }
    }
}
