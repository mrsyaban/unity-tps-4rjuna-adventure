using UnityEngine;

public class JendralWeaponManager : MonoBehaviour, IEnemyWeapon
{
    [Header("Damage")]
    [SerializeField] float BaseSwordDamage;
    [SerializeField] float BaseAoEDamage;

    [Header("Pet")]
    [SerializeField] GameObject pet;
    [HideInInspector] bool PetBuff1 = true;

    void Start()
    {
        GameObject jendralPet = Instantiate(pet, transform.position + new Vector3(0, 0, 2), Quaternion.identity);
        PetIncreaseManager jendralPetManager = jendralPet.GetComponent<PetIncreaseManager>();
        jendralPetManager.master = transform;
        PetIncreaseHealth jendralPetHealth = jendralPet.GetComponent<PetIncreaseHealth>();
        jendralPetHealth.weapon = this;
        jendralPetHealth.index = 1;
    }

    public void DisableBuff(int index)
    {
        if (index == 1)
        {
            PetBuff1 = false;
        }
    }

    public float GetSwordDamage()
    {
        return BaseSwordDamage * (1 + (PetBuff1 ? 0.2f : 0f));
    }

    public float GetAoEDamage()
    {
        return BaseAoEDamage * (1 + (PetBuff1 ? 0.2f : 0f));
    }

}