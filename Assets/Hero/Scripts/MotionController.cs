using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionController : MonoBehaviour
{
    //[SerializeField] LayerMask groundMask;
    [SerializeField] float _moveSpeed = 5;
    [SerializeField] float _maxJumpHeigth = 2.0f;
    [SerializeField] float _maxJumpTime = .5f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float hInput, vInput;
    [SerializeField] Vector3 _velocity;
    [SerializeField] CharacterController _characterController;
    [SerializeField] Animator _animator;

    void Update()
    {
        var movementDirection = CalculateMovementDirection();
        HandleMovement(movementDirection);
        HandleRotation(movementDirection);
        HandleGravity();
        HandleJump();
    }

    void HandleRotation(Vector3 movementDirection)
    {
        // TODO solo rotar en el eje Y
    }

    void HandleMovement(Vector3 movementDirection)
    {
        _characterController.Move(movementDirection * _moveSpeed * Time.deltaTime);
        _animator.SetFloat("hInput", hInput);
        _animator.SetFloat("vInput", vInput);
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

    void HandleGravity()
    {
        if (!_characterController.isGrounded)
        {
            _velocity.y += gravity * Time.deltaTime;
            _animator.SetTrigger("Airbourne");
        }
        else if (_velocity.y < 0)
        {
            _velocity.y = -2;
            _animator.SetTrigger("Landing");
        }
        _characterController.Move(_velocity * Time.deltaTime);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            float timeToApex = _maxJumpTime / 2;
            gravity = (-2 * _maxJumpHeigth) / Mathf.Pow(timeToApex, 2);
            var initialJumpVelocity = (2 * _maxJumpHeigth) / timeToApex;
            _velocity.y = initialJumpVelocity;
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
