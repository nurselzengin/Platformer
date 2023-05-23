using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Vector2 direction;
    Vector2 target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPos;
    [SerializeField] GameObject gunLight;
    public bool isClose;
    private float nextFire;
    [SerializeField] float fireRate;
    [SerializeField] ParticleSystem muzzleEffect;
    
    [Header("Move Rate")]
    [SerializeField] float easyRate;
    [SerializeField] float normalRate;
    [SerializeField] float hardRate;



    private void Start()
    {
        fireRate = HardenedScript.instance.HardenedLevel(fireRate, easyRate, normalRate, hardRate);
    }
    void Update()
    {
        GunDirection();
        GunLight();
        

    }
    void GunDirection()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            target = player.transform.position;
            direction = target - (Vector2)transform.position; // Kendi noktasından karakterin bulunduğu noktayı çıkararak hedefi bulan formül
            transform.right = -direction;
        }

    }
    void BulletSpawn()
    {
        Instantiate(bulletPrefab, bulletSpawnPos.position, transform.rotation);
        Instantiate(muzzleEffect, bulletSpawnPos.position, Quaternion.identity);
    }
    void GunLight()
    {
        if (isClose)
        {
            gunLight.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            gunLight.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
    public void Fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            BulletSpawn();
        }
        
    }

}
