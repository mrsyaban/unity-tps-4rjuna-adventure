using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public GameObject petPenyembuh;
    public GameObject petPenyerang;
    public bool spawnNewPet;

    GameObject playerObject;
    List<GameObject> possiblePetsObject = new();
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        possiblePetsObject.Add(petPenyembuh);
        possiblePetsObject.Add(petPenyerang);
        SpawnPet();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.Instance.petsHealth[0] <= 0f)
        {
            
        }
    }

    private void SpawnPet()
    {
        bool[] ownedPets = GameStateManager.Instance.petsBought;
        float[] petsHealth = GameStateManager.Instance.petsHealth;
        //bool[] ownedPets = new[] { true, true };
        //float[] petsHealth = new[] { 100f, 100f };
        for (int i = 0; i < ownedPets.Length; i++)
        {
            if (ownedPets[i] && petsHealth[i] > 0)
            {
                GameObject pet = null;
                pet = Instantiate(possiblePetsObject[i], playerObject.transform.position + Vector3.right, playerObject.transform.rotation);
                var petHealth = pet.GetComponent<PetHealth>();
                if (petHealth != null)
                {
                    //Debug.Log("petHealth != null");
                    petHealth.currentHealth = petsHealth[i];
                    petHealth.healthToBeReduced = petHealth.startingHealth - petsHealth[i];
                    petHealth.SetManager(this);
                }
            }
        }
    }
}
