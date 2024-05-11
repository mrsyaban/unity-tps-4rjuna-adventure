using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [HideInInspector] Transform playerPos;
    [SerializeField] EnemyHealth enemyHealth;

    [Header("Damage")]
    [SerializeField] float BaseBulletDamage;
    [SerializeField] float BaseAoEDamage;
    [HideInInspector] bool PetBuff1 = false;
    [HideInInspector] bool PetBuff2 = false;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        fireRateTimer = fireRate;
    }

    public bool IsCanFire() 
    {
        if (enemyHealth.health <= 0) return false; 
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
        SpawnBullet( new Vector3(0f, 0f, 0f));
        SpawnBullet( new Vector3(0.1f, 0f, 0f));
        SpawnBullet( new Vector3(0f, 0.1f, 0f));
        SpawnBullet( new Vector3(0f, 0f, 0.1f));
        
    }

    void SpawnBullet(Vector3 offset)
    {
        GameObject currentBullet = Instantiate(bullet, bulletSpawner.position, bulletSpawner.rotation);
        RajaBulletManager bulletManager = currentBullet.GetComponent<RajaBulletManager>();
        bulletManager.weapon = this;
        Rigidbody rigidbody = currentBullet.GetComponent<Rigidbody>();
        rigidbody.AddForce((bulletSpawner.forward + offset) * bulletVelocity, ForceMode.Impulse);
    }

    public float GetBulletDamage()
    {
        return BaseBulletDamage * (1 + (PetBuff1 ? 0f : 0.2f) + (PetBuff2 ? 0f : 0.2f));
    }

    public float GetAoEDamage()
    {
        return BaseAoEDamage * (1 + (PetBuff1 ? 0f : 0.2f) + (PetBuff2 ? 0f : 0.2f));
    }

    public void GiveBuff(int index)
    {
        if (index == 1)
        {
            PetBuff1 = true;
        }
        else if (index == 2)
        {
            PetBuff2 = true;
        }
    }
    public void ClearBuff(int index)
    {
        if (index == 1)
        {
            PetBuff1 = false;
        }
        else if (index == 2)
        {
            PetBuff2 = false;
        }
    }
}
