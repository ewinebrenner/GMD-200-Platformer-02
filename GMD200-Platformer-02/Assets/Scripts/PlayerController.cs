using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public PlayerControllerSettings settings;

    private Rigidbody2D _rb;
    private Animator _animator;
    float _xInput;
    bool _jumpPressed;//Was the jump button pressed this frame?
    bool _onGround;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }
    void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, settings.jumpSpeed);
        _jumpPressed = false;
    }
    // Update is called once per frame
    void Update()
    {
        _xInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            _jumpPressed = true;
        }
        _animator.SetBool("OnGround", _onGround);

        //_rb.AddForce(Vector2.right * xInput * walkSpeed);
    }
    private void FixedUpdate()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, settings.groundLayer);

        _onGround = (rayHit.collider != null);

        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.5f, _onGround ? Color.green : Color.red);


        _rb.velocity = new Vector2(_xInput * settings.walkSpeed, _rb.velocity.y);
        if (_jumpPressed && _onGround)
        {
            Jump();
        }
        _jumpPressed = false;
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    _onGround = true;
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    _onGround = false;
    //}
}
