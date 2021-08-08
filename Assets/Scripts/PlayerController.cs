using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D _rigidbody;
    private LayerMask _groundLayerMask;
    private Animator _animator;
    private static readonly int IsAlive = Animator.StringToHash("isAlive");
    private static readonly int IsGrounded = Animator.StringToHash("isGrounded");

    private const float JumpForce = 20.0f;
    private const float RunningSpeed = 6.0f;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundLayerMask = LayerMask.GetMask("Ground");
        _animator = GetComponentInChildren<Animator>();
        _animator.SetBool(IsAlive, true);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        _animator.SetBool(IsGrounded, IsOnTheFloor());
    }

    private void FixedUpdate() {
        if (_rigidbody.velocity.x < RunningSpeed || _rigidbody.velocity.x > RunningSpeed) {
            // _rigidbody.velocity = (new Vector2(RunningSpeed, _rigidbody.velocity.y));
        }
    }

    private void Jump() {
        if (IsOnTheFloor()) {
            _rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    private bool IsOnTheFloor() {
        return Physics2D.Raycast(this.transform.position, Vector2.down, 1.0f, _groundLayerMask);
    }
}