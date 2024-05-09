using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunBulletManager : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    float timer;

    private float timer2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToDestroy) Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {       
        if (!collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject); // Destroy the GameObject this script is attached to
        }
    }
}
