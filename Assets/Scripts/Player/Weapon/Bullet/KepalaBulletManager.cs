using UnityEngine;

public class KepalaBulletManager : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToDestroy) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject); // Destroy the GameObject this script is attached to
        }
    }
}
