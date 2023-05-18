using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;
   
    [SerializeField] private float jumpPower; //sadece scriptin oldu�u yerden eri�ilebilmesini sa�l�yor inspectada de�i�tirilebilir hale getiriirli
    [SerializeField] SoundManager soundManager;
    [SerializeField] float radius;
    public static float gravityScale = 1;
    public static float fallGravityScale = 15;
    [SerializeField] Transform feetPos;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float startJump;
    float jumpTime;
    bool isJumping;
    bool doubleJump;


    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }

  
    void Update()
    {
       
        Gravity();
        JumpAction();
    }
    private bool IsGrounded() //dokunuyorsa true ya da false d�nd�recek dokunmazsa z�plamayacak //havada z�plmas�n� engelledik
    {
        return Physics2D.OverlapCircle(feetPos.position, radius, layerMask);
    }
    void Gravity()
    {
        //Debug.Log("Rigidbody Velocity.Y" + rb.velocity.y);
        //Debug.Log("Rigidbody Velocity.X" + rb.velocity.x);
        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallGravityScale;
        }
    }


    void JumpAction()
    {
        if (Movement.isDashing)
        {
            return;
        }
        if (Input.GetButtonDown("Jump") && IsGrounded() && LevelManager.canMove)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = true;
            jumpTime = startJump;
            //soundManager.JumpSound();
            SoundManager.instance.PlayWithIndex(8);
        }
        else if (Input.GetButtonDown("Jump") && doubleJump)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            doubleJump = false;
        }

        if (Input.GetButton("Jump") && isJumping ) 
        { 
            if(jumpTime > 0)
            {
                rb.AddForce(Vector2.up * 2f, ForceMode2D.Force);
                jumpTime -= Time.deltaTime;
            }
            else 
            { 
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }
}
