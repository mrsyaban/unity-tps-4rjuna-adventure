using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RajaWeaponManager: MonoBehaviour, IEnemyWeapon
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

    [Header("Pet")]
    [SerializeField] GameObject pet;
    [HideInInspector] bool PetBuff1 = true;
    [HideInInspector] bool PetBuff2 = true;

    void Start()
    {
        GameObject pet1 = Instantiate(pet, transform.position + new Vector3(0, 0, 2), Quaternion.identity);
        pet1.GetComponent<PetIncreaseManager>().master = transform;
        PetIncreaseHealth pet1Health = pet1.GetComponent<PetIncreaseHealth>();
        pet1Health.weapon = this;
        pet1Health.index = 1;

        GameObject pet2 = Instantiate(pet, transform.position + new Vector3(0, 0, 2), Quaternion.identity);
        pet2.GetComponent<PetIncreaseManager>().master = transform;
        PetIncreaseHealth pet2Health = pet2.GetComponent<PetIncreaseHealth>();
        pet2Health.weapon = this;
        pet2Health.index = 2;


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
        Debug.Log("PetBuff 1 : " + PetBuff1);
        Debug.Log("PetBuff 2 : " + PetBuff2);
        Debug.Log("Calculate : " + BaseBulletDamage * (1 + (PetBuff1 ? 0f : 0.2f) + (PetBuff2 ? 0f : 0.2f)));
        return BaseBulletDamage * (1 + (PetBuff1 ? 0.2f : 0f) + (PetBuff2 ? 0.2f : 0f));
    }

    public float GetAoEDamage()
    {
        return BaseAoEDamage * (1 + (PetBuff1 ? 0.2f : 0f) + (PetBuff2 ? 0.2f : 0f));
    }

    public void DisableBuff(int index)
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
