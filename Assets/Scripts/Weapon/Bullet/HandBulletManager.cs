using UnityEngine;

public class HandBulletManager : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    private float damage = 10;
    // float timer;

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
        if (collision.gameObject.GetComponentInParent<EnemyHealth>())
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponentInParent<EnemyHealth>();
            enemyHealth.TakeDamage(damage);
            Debug.Log("Darah : " + enemyHealth.health);
        }
        Destroy(gameObject);
    }
}
