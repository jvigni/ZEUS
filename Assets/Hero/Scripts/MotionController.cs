using UnityEngine;

public class MotionController : MonoBehaviour
{
    [SerializeField] float _walkSpeed = 3f;
    [SerializeField] float _runSpeed = 5f;
    [SerializeField] float _maxJumpHeigth = 2f;
    [SerializeField] float _maxJumpTime = .5f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] CharacterController _characterController;
    [SerializeField] Animator _animator;

    void Update()
    {
        var movementDirection = CalculateMovementDirection();
        var speed = Input.GetKey(KeyCode.LeftShift) ? _runSpeed : _walkSpeed;
        var velocity = CalculateVelocity(movementDirection, speed);
        
        HandleMovement(velocity);
        HandleRotation(movementDirection);
    }

    Vector3 CalculateVelocity(Vector3 movementDirection, float speed)
    {
        var velocity = movementDirection * speed * Time.deltaTime;

        // Jump:
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            float timeToApex = _maxJumpTime / 2;
            gravity = (-2 * _maxJumpHeigth) / Mathf.Pow(timeToApex, 2);
            var initialJumpVelocity = (2 * _maxJumpHeigth) / timeToApex;
            velocity.y = initialJumpVelocity;
            _animator.SetTrigger("Jump");
        }

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
        Vector3 targetPostition = transform.position + movementDirection * Time.deltaTime; // time delta time??
        // Rotates only on Y axis:
        targetPostition.x = 0;
        targetPostition.z = 0;
        transform.LookAt(targetPostition);
    }

    void HandleMovement(Vector3 velocity)
    {
        _characterController.Move(velocity);
        _animator.SetFloat("HorizontalVelocity", velocity.x);
        _animator.SetFloat("VerticalVelocity", velocity.y);
    }

    Vector3 CalculateMovementDirection()
    {
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");

        var xRedDir = transform.right * hInput;
        var yGreenDir = transform.up;
        var zBlueDir = transform.forward * vInput;
        var direction = (xRedDir + zBlueDir + yGreenDir).normalized;
        return direction;
    }

    void OnLand() // Anim
    {
        // TODO ground SFX + particles
    }

    void FootR() // Anim
    {
        OnFootstep();
    }

    void FootL() // Anim
    {
        OnFootstep();
    }

    void OnFootstep() // Anim
    {
        // TODO:
        //var index = Random.Range(0, FootstepAudioClips.Length);
        //AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(_controller.center), FootstepAudioVolume);
    }
}
