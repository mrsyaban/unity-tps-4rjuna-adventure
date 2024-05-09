using UnityEngine;

public class HandGunManager : MonoBehaviour
{
    [Header("Fire Rate")]
    [SerializeField] private float fireRate;
    private float _fireRateTimer;
    [SerializeField] private bool semiAuto;
    
    [Header("Bullet Properties")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform barrelPos;
    [SerializeField] private float bulletVelocity;
    [SerializeField] private int bulletPerShot;
    private AimStateManager _aim;
    public float damage = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        _aim = GetComponentInParent<AimStateManager>();
        _fireRateTimer = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldFire())
        {
            Fire();
        }
        
    }

    private bool ShouldFire()
    {
        _fireRateTimer += Time.deltaTime;
        if (_fireRateTimer < fireRate) return false;
        if (semiAuto && Input.GetKeyDown(KeyCode.Mouse0)) return true;
        if (!semiAuto && Input.GetKey(KeyCode.Mouse0)) return true;
        return false;
    }

    private void Fire()
    {
        _fireRateTimer = 0;
        barrelPos.LookAt(_aim.aimPos);
        for (int i = 0; i < bulletPerShot; i++)
        {
            GameObject currentBullet = Instantiate(bullet, barrelPos.position, barrelPos.rotation);

            // HandBulletManager bulletManager = currentBullet.GetComponent<HandBulletManager>();
            // bulletManager.weapon = this;

            Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
            rb.AddForce(barrelPos.forward * bulletVelocity, ForceMode.Impulse);
        }
    }
}
