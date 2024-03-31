using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MotionController : MonoBehaviour
{
    [SerializeField] float _walkSpeed = 3f; // in m/s
    [SerializeField] float _runSpeed = 5f; // in m/s
    [SerializeField] float _maxJumpHeigth = 2.0f;
    [SerializeField] float _maxJumpTime = .5f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float hInput, vInput;
    [SerializeField] CharacterController _characterController;
    [SerializeField] Animator _animator;

    void Update()
    {
        var movementDirection = CalculateMovementDirection();
        var speed = Input.GetKey(KeyCode.LeftShift) ? _runSpeed : _walkSpeed;
        var velocity = CalculateVelocity(movementDirection, speed);
        
        HandleMovement(movementDirection);
        HandleRotation(movementDirection);
        HandleJump(velocity);
    }

    Vector3 CalculateVelocity(Vector3 movementDirection, float speed)
    {
        var velocity = movementDirection * speed * Time.deltaTime;

        // Gravity:
        if (!_characterController.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
            _animator.SetTrigger("Airbourne");
        }
        else if (velocity.y < 0)
        {
            velocity.y = -2;
            _animator.SetTrigger("Landing");
        }

        return velocity;
    }

    void HandleRotation(Vector3 movementDirection)
    {
        // TODO solo rotar en el eje Y
    }

    void HandleMovement(Vector3 velocity)
    {
        _characterController.Move(velocity);
        _animator.SetFloat("HorizontalVelocity", velocity.x);
        _animator.SetFloat("VerticalVelocity", velocity.y);
    }

    Vector3 CalculateMovementDirection()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        var xRedDir = transform.right * hInput;
        var yGreenDir = transform.up;
        var zBlueDir = transform.forward * vInput;
        var dir = (xRedDir + zBlueDir + yGreenDir).normalized;
        return dir;
    }

    void HandleJump(Vector3 velocity)
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            float timeToApex = _maxJumpTime / 2;
            gravity = (-2 * _maxJumpHeigth) / Mathf.Pow(timeToApex, 2);
            var initialJumpVelocity = (2 * _maxJumpHeigth) / timeToApex;
            velocity.y = initialJumpVelocity;
            _animator.SetTrigger("Jump");
        }
    }

    void OnLand() // Called by animation
    {
        // TODO ground SFX + particles
    }

    void FootR() // Called by animation
    {
        OnFootstep();
    }

    void FootL() // Called by animation
    {
        OnFootstep();
    }

    void OnFootstep() // Called by animation
    {
        // TODO
        //var index = Random.Range(0, FootstepAudioClips.Length);
        //AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(_controller.center), FootstepAudioVolume);
    }
}
