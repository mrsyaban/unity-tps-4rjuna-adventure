using UnityEngine;

public class ShotGunManager : MonoBehaviour
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
    [SerializeField] private float xOffset;
    private AimStateManager _aim;
    
    private GameObject _rightHand;
    private UnityEngine.Animations.Rigging.MultiAimConstraint _twoBoneIKRight;
    
    [HideInInspector] public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _aim = GetComponentInParent<AimStateManager>();
        _fireRateTimer = fireRate;
        animator = FindParentObjectByName(transform, "PlayerObject").GetComponent<Animator>();
        _rightHand = GameObject.Find("JammoPlayer/Rig 1/RightHandAim");
        _twoBoneIKRight = _rightHand.GetComponent<UnityEngine.Animations.Rigging.MultiAimConstraint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldFire())
        {
            Fire();
        }
        
        if (animator.GetBool("IsAim") == true)
        {
            _twoBoneIKRight.weight = 1f;
        }
        else
        {
            _twoBoneIKRight.weight = 0f;
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
            SpawnBullet(new Vector3(0.1f, 0f, 0f));
            SpawnBullet(new Vector3(-0.1f, 0f, 0f));
            SpawnBullet(new Vector3(0f, 0.1f, 0f));
            SpawnBullet(new Vector3(0f, -0.1f, 0f));
            SpawnBullet(new Vector3(0f, 0f, 0.1f));
            SpawnBullet(new Vector3(0f, 0f, 0f));
            SpawnBullet(new Vector3(0.1f, 0.1f, 0f));
            SpawnBullet(new Vector3(0f, 0.1f, 0.1f));
        }
    }

    private void SpawnBullet(Vector3 offset)
    {
        GameObject currentBullet1 = Instantiate(bullet, barrelPos.position, barrelPos.rotation);
        Rigidbody rb = currentBullet1.GetComponent<Rigidbody>();
        if (animator.GetBool("IsAim") == true)
        {
            Vector3 offsetForward = barrelPos.forward + offset; // Adjust offsetX as needed
            rb.AddForce(offsetForward * bulletVelocity, ForceMode.Impulse);
        }
        else
        {
            Vector3 offsetForward = barrelPos.forward + new Vector3(xOffset, 0f, 0f); // Adjust offsetX as needed
            rb.AddForce(offsetForward * bulletVelocity, ForceMode.Impulse);
        }
    }
    
    private GameObject FindParentObjectByName(Transform child, string parentName)
    {
        // Start from the child's parent
        Transform parent = child.parent;

        // Iterate through the hierarchy to find the parent object by name
        while (parent != null)
        {
            if (parent.name == parentName)
            {
                // Return the parent object if its name matches
                return parent.gameObject;
            }

            // Move to the next parent
            parent = parent.parent;
        }

        // If the parent object is not found, return null
        return null;
    }
}