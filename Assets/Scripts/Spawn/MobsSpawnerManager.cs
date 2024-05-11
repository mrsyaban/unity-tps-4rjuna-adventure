using UnityEngine;
using Random = UnityEngine.Random;

public class MobsSpawnerManager : MonoBehaviour
{
    [Header("from easy to hard mob")]
    [SerializeField] public GameObject[] mobPrefabs;

    [Header("Spawn properties")]
    [SerializeField] public Transform[] spawnPoints;
    [SerializeField] public float spawnRate;
    [SerializeField] public float spawnTimeStart;
    
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnTimeStart, spawnRate);
    }
    
    private static int GetRandomValue(params RandomSelection[] selections)
    {
        var rand = Random.value;
        float currentProb = 0;
        foreach (var selection in selections)
        {
            currentProb += selection.GetProbability();
            if (rand <= currentProb)
            {
                return selection.GetValue();
            }
        }

        return -1;
    }
    
    private void Spawn()
    {
        var mobCode = mobPrefabs.Length switch
        {
            1 => 0,
            2 => GetRandomValue(new RandomSelection(0, .7f), new RandomSelection(1, .3f)),
            _ => GetRandomValue(new RandomSelection(0, .6f), new RandomSelection(1, .2f), new RandomSelection(2, .2f))
        };

        var spawnCode = Random.Range(0, spawnPoints.Length);
        Instantiate(mobPrefabs[mobCode], spawnPoints[spawnCode].position, spawnPoints[spawnCode].rotation);
    }

}

internal readonly struct RandomSelection
{
    private readonly int _value;
    private readonly float _probability;

    public RandomSelection(int value, float probability) {
        _value = value;
        _probability = probability;
    }

    public int GetValue() {
        return _value;
    }

    public float GetProbability() {
        return _probability;
    }
}