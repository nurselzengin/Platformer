using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] float bulletSpeed;
    Rigidbody2D rb;
    DelayScript delay;
    PlayerHealth health;
    [SerializeField] ParticleSystem groundParticle;
    [SerializeField] ParticleSystem playerParticle;
    [SerializeField] ParticleSystem playerHitParticle;
    [SerializeField] ParticleSystem playerBlockParticle;

    [SerializeField] GameObject player;
    
   
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        delay = GameObject.Find("Level Manager").GetComponent<DelayScript>();
        health = GameObject.Find("Level Manager").GetComponent <PlayerHealth>();
    }
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player == null || CountManager.instance.EndCount())
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
          rb.velocity = -transform.right * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
     
        if (collision.gameObject.CompareTag("Player") && LevelManager.canMove && !Movement.blocking)
        {
            Animator anim = collision.gameObject.GetComponent<Animator>();
            LevelManager.canMove = false;
            anim.SetTrigger("Die");
  
            Instantiate(playerParticle, transform.position, Quaternion.identity);
            Instantiate(playerHitParticle, transform.position, Quaternion.identity);

        }
        else if(collision.gameObject.CompareTag("Player") && Movement.blocking)
        {
            Instantiate(playerBlockParticle, transform.position, Quaternion.identity);

        }
        if (collision.gameObject.CompareTag("Ground"))
            Instantiate(groundParticle, transform.position, Quaternion.identity);
    }
}
