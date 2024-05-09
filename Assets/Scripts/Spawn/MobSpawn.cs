using UnityEngine;

public class MobSpawn : MonoBehaviour 
{  
    [SerializeField] public GameObject mob;
    [SerializeField] public float timer;
    private float timerCount;

    void Start() 
    {
        timerCount = 0;
    }

    void Update()
    {
        timerCount += Time.deltaTime;
        if (timerCount >= timer) 
        {
            timerCount = 0;
            Instantiate(mob, transform.position, Quaternion.identity);
            // GameObject enemyManager = GameObject.FindGameObjectWithTag("EnemyManager");
            // enemyManager.GetComponent<MobManager>().Spawn(mob, transform);
        }
    }
}