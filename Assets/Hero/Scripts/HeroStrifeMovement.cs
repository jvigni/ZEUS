using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class HeroStrifeMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float gravity = -9.81f;
    Vector3 zMotion;
    CharacterController _controller;
    Animator _animator;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");

        var xRedDir = transform.right * vInput;
        var yGreenDir = transform.up;
        var zBlueDir = transform.forward * hInput;
        var dir = (xRedDir + zBlueDir + yGreenDir).normalized;
        var motion = dir * moveSpeed * Time.deltaTime;

        motion = ApplyGravity(motion);

        _controller.Move(motion);

        _animator.SetFloat("hInput", hInput);
        _animator.SetFloat("vInput", vInput);

    }

    Vector3 ApplyGravity(Vector3 motion)
    {
        if (!_controller.isGrounded)
        {
            motion.y += gravity * Time.deltaTime;
            //_animator.SetTrigger("Airbourne");
        }
        else if (motion.y < 0)
        {
            motion.y = -2; // TODO why?
            _animator.SetTrigger("Landing");
        }
        return motion;
    }
}
