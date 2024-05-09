using UnityEngine;

public class HandBulletManager : MonoBehaviour
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
        Destroy(this.gameObject);
    }
}
