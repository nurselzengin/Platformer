using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public float moveSpeed;
    [SerializeField] GameObject gameoverText;
    [SerializeField] float playerYBoundry;
    LevelManager levelManager;
    SoundManager soundManager;
    DelayScript delayScript;
    UiManager uiManager;
    PlayerHealth playerHealth;
    private void Awake()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        delayScript = GameObject.Find("Level Manager").GetComponent<DelayScript>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UiManager>();
        playerHealth = GameObject.Find("Level Manager").GetComponent<PlayerHealth>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //inspector penceresinde player�n rigidboysini al�yor oyunu �al��t�r�nca
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void MovementAction()
    {
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
            soundManager.DeathbyFall();
           

        }
    }

    // Update is called once per frame
    void Update()
    {
        MovementAction();
        PlayerDestroyer();
    }
}
