using System.Collections;
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
    }
    void Start()
    {
        Cancel();
        rb = GetComponent<Rigidbody2D>(); 
        tr = GetComponent<TrailRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        MovementAction();
        PlayerDestroyer();
        StartDash();
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
    }

    void StartDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && horizontalMove != 0)
        {
            StartCoroutine(Dash());
            SoundManager.instance.PlayWithIndex(14);
        }

    }
}
