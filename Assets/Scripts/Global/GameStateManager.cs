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
    // karena player bisa punya 2 pet saja 
    public bool[] petsBought = new []{false, false};
    // -1 artinya blm kebeli, 0 artinya udah mati
    public float[] petsHealth = new[] { -1f, -1f };
    
    // BUAT STATISTIK
    public int bulletShot;
    // BUAT SETTINGS
    public string playerName;
    public string difficulty;
    public float gameVolume;

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

    public void LoadGameState()
    {
        // Nanti diisi list saved game kaya punya kinan krn gabisa nilai awal diinisialisasi lewat editor
    }

    public int GetCoins()
    {
        return coin;
    }


    public void AddCoin(int val)
    {
        coin += val;
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public void SetDifficulty(string diff)
    {
        difficulty = diff;
    }

    public void SetGameVolume(float vol)
    {
        gameVolume = vol;
    }

    public void IncreaseGameVolume(int vol)
    {
        if(gameVolume + vol > 100)
        {
            gameVolume = 100;
        }
        else if(gameVolume + vol < 0)
        {
            gameVolume = 0;
        }
        else
        {
            gameVolume += vol;
        }
    }

    public void DecreaseGameVolume(int vol)
    {
        if(gameVolume - vol > 100)
        {
            gameVolume = 100;
        }
        else if(gameVolume - vol < 0)
        {
            gameVolume = 0;
        }
        else
        {
            gameVolume -= vol;
        }
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

    public void BuyPet(int i)
    {
        petsBought[i] = true;
    }
}
