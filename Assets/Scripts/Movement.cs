using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private TrailRenderer tr;
    public float moveSpeed;
    [SerializeField] GameObject gameoverText;
    [SerializeField] float playerYBoundry;
    LevelManager levelManager;
    DelayScript delayScript;
    UiManager uiManager;
    PlayerHealth playerHealth;
    private float horizontalMove;
    [SerializeField] Animator anim;
    public static bool blocking;
    Jump jump;
    public static bool died;



    public static bool canDash = true;
    public static bool isDashing = false;
    [SerializeField] float dashAmount;
    [SerializeField] float dashCooldown;
    [SerializeField] float dashTime;
    public static bool dashed;
    private void Awake()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        delayScript = GameObject.Find("Level Manager").GetComponent<DelayScript>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UiManager>();
        playerHealth = GameObject.Find("Level Manager").GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        jump = GetComponent<Jump>();
    }
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>(); 
        tr = GetComponent<TrailRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Cancel();
    }
    void Update()
    {
        MovementAction();
        PlayerDestroyer();
        StartDash();
        Block();
    }

    void MovementAction()
    {
        if (isDashing)
        {
            return;
        }
        if (LevelManager.canMove)
        {
            horizontalMove = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);
            SpriteFlip(horizontalMove);
            anim.SetFloat("Move", Mathf.Abs(horizontalMove));
        }
        else
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
        }
        
    }

    void SpriteFlip(float horizontalMove)
    {
        if (horizontalMove > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalMove < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    void PlayerDestroyer()
    {
        if (transform.position.y < playerYBoundry)
        { 
            //uiManager.GetComponent<Canvas>().enabled = true;
            //restart butonu aktifleşmesin diye kapanır
            playerHealth.Lives();

            if (delayScript.delayTime == true)
            {
                delayScript.StartDelayTime();
            }
            Destroy(gameObject);
            Movement.Cancel();
            SoundManager.instance.PlayWithIndex(3);
        }
    }
    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        dashed = true;
        rb.gravityScale = 0;
        Jump.fallGravityScale = 0;
        tr.emitting = true;
        rb.velocity = new Vector2(horizontalMove * dashAmount, 0);
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = 1;
        Jump.fallGravityScale = 15;
        isDashing = false;
        tr.emitting = false;
        yield return new WaitForSeconds(dashCooldown);
        dashed = false;
        canDash = true;
    }


    public static void Cancel()
    {
        canDash = true;
        isDashing = false;
        dashed = false;
        Jump.fallGravityScale = 15;
        LevelManager.canMove = true;
        died = false;
    }

    void StartDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && horizontalMove != 0)
        {
            StartCoroutine(Dash());
            SoundManager.instance.PlayWithIndex(14);
        }
        

    }
    public void Die()
    {
        Destroy(gameObject);
        PlayerHealth.instance.Lives();
        Cancel();
        if (DelayScript.instance.delayTime)
        { 
            DelayScript.instance.StartDelayTime();
        }
    }

    void Block()
    {
        if (Input.GetMouseButton(0) && jump.IsGrounded() && !died)
        {
            anim.SetBool("Shield", true);
            blocking = true;
            rb.velocity = Vector2.zero;
            LevelManager.canMove = false;
            
        }
        else if (Input.GetMouseButtonUp(0) && jump.IsGrounded() && !died)
        {
            anim.SetBool("Shield", false);
            blocking = false;
            LevelManager.canMove = true;
        }
        
    }
    public void Died()
    {
        died = true;
    }
}
