using UnityEngine;

public class PetAttackerBulletManager : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    float timer;

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
        if (!collision.gameObject.CompareTag("PlayerPet"))
        {
            Destroy(gameObject);
        }
    }
}