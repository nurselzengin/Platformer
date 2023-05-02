using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float jumpPower;
    [SerializeField] float radius;

    [SerializeField] float gravityScale;
    [SerializeField] float fallGravityScale;

    [SerializeField] Transform feetPos;
    [SerializeField] LayerMask layerMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        Gravity();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(feetPos.position, radius, layerMask);
    }

    void Gravity()
    {

        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y< 0)
        {
            rb.gravityScale = fallGravityScale;
        }
    }
}
