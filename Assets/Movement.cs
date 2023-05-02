using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    [SerializeField] GameObject gameoverText;
    private SpriteRenderer spriteRenderer;
    [SerializeField] float playerYBoundry;
    LevelManager levelManager;
    // Start is called before the first frame update
    private void Awake()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementAction();
        PlayerDestroyer();
    }
    void MovementAction()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);
        SpriteFlip(horizontalMove);
        
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
            Destroy(gameObject);
            levelManager.RespawnPlayer();
        }

            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Die"))
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }
}
