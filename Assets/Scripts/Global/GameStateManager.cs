using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    [HideInInspector]
    public int coin;
    [HideInInspector]
    public float playerHealth;
    [HideInInspector]
    public Vector3 playerPosition;
    [HideInInspector]
    public string levelName;
    [HideInInspector]
    public bool hasDamageOrb;
    [HideInInspector]
    public int countDamageOrb = 0;
    [HideInInspector]
    public bool hasSpeedOrb;
    [HideInInspector]
    public float speedOrbTime;
    [HideInInspector]
    public float lifetime = 0;
    [HideInInspector]
    public float distance = 0;
    [HideInInspector]
    public int onHitTarget = 0;
    [HideInInspector]
    public int jendralKill = 0;
    [HideInInspector]
    public int kepalaKrocoKill = 0;
    [HideInInspector]
    public int krocoKill = 0;
    [HideInInspector]
    public bool loadSpeed = false;
    public bool loadHealth = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddCoin(int val)
    {
        coin += val;
    }
    
    // Method to update player health
    public void UpdatePlayerHealth(float newHealth)
    {
        playerHealth += newHealth;
    }

    // Method to update player position
    public void UpdatePlayerPosition(Vector3 newPosition)
    {
        playerPosition = newPosition;
    }

    // Method to update level name
    public void UpdateLevelName(string newName)
    {
        levelName = newName;
    }

    // Method to update damage orb status
    public void UpdateDamageOrbStatus()
    {
        hasDamageOrb = true;
        countDamageOrb++;
    }

    // Method to update speed orb status
    public void UpdateSpeedOrbStatus(bool hasOrb, float orbTime)
    {
        hasSpeedOrb = hasOrb;
        speedOrbTime = orbTime;
    }

    // Method to update lifetime
    public void UpdateLifetime(float newLifetime)
    {
        lifetime = newLifetime;
    }

    // Method to update distance
    public void UpdateDistance(float newDistance)
    {
        distance = newDistance;
    }

    // Method to update on-hit target count
    public void UpdateOnHitTarget()
    {
        onHitTarget ++;
    }

    // Method to update jendral kill count
    public void UpdateJendralKill()
    {
        jendralKill ++;
    }

    // Method to update kepala kroco kill count
    public void UpdateKepalaKrocoKill()
    {
        kepalaKrocoKill ++;
    }

    // Method to update kroco kill count
    public void UpdateKrocoKill()
    {
        krocoKill ++;
    }
}
