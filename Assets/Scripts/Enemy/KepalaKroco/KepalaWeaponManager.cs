using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KepalaWeaponManager: MonoBehaviour
{
    [Header("Fire Rate")]
    [SerializeField] float fireRate;
    float fireRateTimer;

    [Header("Bullet Props")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawner;
    [SerializeField] float bulletVelocity;
    [SerializeField] int bulletPerShot;
    [HideInInspector] Transform playerPos;
    [SerializeField] EnemyHealth enemyHealth;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        fireRateTimer = fireRate;
    }

    public bool IsCanFire() 
    {
        if (enemyHealth.health <= 0) return false; 
        fireRateTimer += Time.deltaTime;
        if (fireRateTimer < fireRate) {
            return false;
        }
        else {
            return true;
        }
    }

    public void Fire()
    {
        fireRateTimer = 0; 
        bulletSpawner.LookAt(playerPos);
        SpawnBullet( new Vector3(-0.1f, 0f, 0f));
        SpawnBullet( new Vector3(0f, -0.1f, 0f));
        SpawnBullet( new Vector3(0f, 0f, -0.1f));
        
    }

    void SpawnBullet(Vector3 offset)
    {
        GameObject currentBullet = Instantiate(bullet, bulletSpawner.position, bulletSpawner.rotation);
        Rigidbody rigidbody = currentBullet.GetComponent<Rigidbody>();
        rigidbody.AddForce((bulletSpawner.forward + offset) * bulletVelocity, ForceMode.Impulse);
    }
}
