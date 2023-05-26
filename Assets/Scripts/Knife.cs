using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Knife : MonoBehaviour
{
    [SerializeField] float turnSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] ParticleSystem particle;
    [SerializeField] float destroyLimit;
    private Rigidbody2D rb;
    [SerializeField] GameObject player;

    [Header("Move Speed")]
    [SerializeField] float easySpeed;
    [SerializeField] float normalSpeed;
    [SerializeField] float hardSpeed;

    void Start()
    {
        moveSpeed = HardenedScript.instance.HardenedLevel(moveSpeed, easySpeed, normalSpeed, hardSpeed);
        rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null || CountManager.instance.EndCount())
        {
            Destroy(gameObject);
        }
        if (transform.position.x < destroyLimit)
            Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        transform.Rotate(-transform.right * turnSpeed);
        rb.velocity = Vector2.left * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && LevelManager.canMove)
        {
            Debug.Log(collision.gameObject.name);
            SoundManager.instance.PlayWithIndex(13);
            Instantiate(particle, collision.gameObject.transform.position, Quaternion.identity);
            Animator anim = collision.gameObject.GetComponent<Animator>();
            anim.SetTrigger("Die");
            LevelManager.canMove = false;
            //Destroy(collision.gameObject);
            //PlayerHealth.instance.Lives();
            //if (DelayScript.instance.delayTime)
            //{
            //    DelayScript.instance.StartDelayTime();
            //}
            //Movement.Cancel();
            Destroy(gameObject);
        }

    }


}
