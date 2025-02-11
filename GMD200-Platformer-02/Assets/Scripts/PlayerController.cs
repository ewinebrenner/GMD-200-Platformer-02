using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 6.0f;
    public float jumpSpeed = 10.0f;
    public LayerMask groundLayer;

    private Rigidbody2D _rb;
    float _xInput;
    bool _jumpPressed;//Was the jump button pressed this frame?
    bool _onGround;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
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
        //_rb.AddForce(Vector2.right * xInput * walkSpeed);
    }
    private void FixedUpdate()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, groundLayer);

        _onGround = (rayHit.collider != null);

        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.5f, _onGround ? Color.green : Color.red);


        _rb.velocity = new Vector2(_xInput * walkSpeed, _rb.velocity.y);
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
