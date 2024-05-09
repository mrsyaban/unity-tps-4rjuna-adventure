using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunBulletManager : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    private float damage = 2; 
    // float timer;

    // private float timer2;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);       
    }

    // Update is called once per frame
    // void Update()
    // {
    //     timer += Time.deltaTime;
    //     if (timer >= timeToDestroy) Destroy(this.gameObject);
    // }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("PlayerBullet"))
        {
            if (collision.gameObject.GetComponentInParent<EnemyHealth>())
            {
                EnemyHealth enemyHealth = collision.gameObject.GetComponentInParent<EnemyHealth>();
                enemyHealth.TakeDamage(damage);
                Debug.Log("Darah : " + enemyHealth.health);
            }
            Destroy(gameObject);
        }
    }
}
