using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public int coin;
    // BUAT STATISTIK
    public int bulletShot;
    public int bulletHit;
    public int distanceTraveled;
    public int playtime;
    public int krocoKilled;
    public int kepalaKrocoKilled;
    public int JendralKrocoKilled;
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
    
}
