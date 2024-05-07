using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RajaWeaponManager: MonoBehaviour
{
    [Header("Fire Rate")]
    [SerializeField] float fireRate;
    float fireRateTimer;

    [Header("Bullet Props")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawner;
    [SerializeField] float bulletVelocity;
    [SerializeField] int bulletPerShot;
    [SerializeField] Transform playerPos;

    void Start()
    {
        fireRateTimer = fireRate;
    }

    public bool IsCanFire() 
    {
        fireRateTimer += Time.deltaTime;
        if (fireRateTimer < fireRate) return false;
        else return true;
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
