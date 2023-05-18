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
    SoundManager soundManager;
    DelayScript delayScript;
    UiManager uiManager;
    PlayerHealth playerHealth;
    [SerializeField] float horizontalMove;


    public static bool canDash = true;
    public static bool isDashing = false;
    [SerializeField] float dashAmount;
    [SerializeField] float dashCooldown;
    [SerializeField] float dashTime;
    public static bool dashed;
    private void Awake()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        delayScript = GameObject.Find("Level Manager").GetComponent<DelayScript>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UiManager>();
        playerHealth = GameObject.Find("Level Manager").GetComponent<PlayerHealth>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //inspector penceresinde player�n rigidboysini al�yor oyunu �al��t�r�nca
        tr = GetComponent<TrailRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void MovementAction()
    {
        if (isDashing)
        {
            return;
        }
        if (LevelManager.canMove)
        {


            float horizontalMove = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);
            //Debug.Log(horizontalMove);
            SpriteFlip(horizontalMove);
        }
        
    }

    void SpriteFlip(float horizontalMove)
    {
        if (horizontalMove > 0)
        {
            spriteRenderer.flipX = false; //sa�sol y�n� x ekseninde
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
            soundManager.DeathbyFall();
           

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash && horizontalMove != 0) 
        {
            StartCoroutine(Dash());
        }
        horizontalMove = Input.GetAxis("Horizontal");
        MovementAction();
        PlayerDestroyer();
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
        Debug.Log("You can dash again");
        canDash = true;
    }


    public static void Cancel()
    {
        canDash = true;
        isDashing = false;
        dashed = false;
        Jump.fallGravityScale = 15;
    }
}
