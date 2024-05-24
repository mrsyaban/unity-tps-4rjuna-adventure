using System.Collections;
using System.Collections.Generic;
using UnityEditor.AI;
using UnityEngine;
using UnityEngine.AI;

public class PetAttackerManager : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
    [HideInInspector] public Animator animator;
    [HideInInspector] public NavMeshAgent agent;
    public float rotationSpeed = 2.0f;
    
    
    [Header("Fire Rate")]
    [SerializeField] private float attackTimer = 0f;
    [SerializeField] public float attackInterval = 1f;
    
    [Header("Bullet Properties")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnerPos;
    [SerializeField] private float bulletVelocity;
    [SerializeField] private float bulletSize;
    [SerializeField] private int bulletPerShot;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        // Find all GameObjects with the specified tags
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Kroco");
        GameObject[] kepalaKrocos = GameObject.FindGameObjectsWithTag("KepalaKroco");
        GameObject[] jendrals = GameObject.FindGameObjectsWithTag("Jendral");
        GameObject[] rajas = GameObject.FindGameObjectsWithTag("Raja");

        // Combine all arrays into one
        GameObject[][] allEnemies = { enemies, kepalaKrocos, jendrals, rajas };
        
        // Find the nearest enemy among all enemy types
        enemy= FindNearestEnemy(allEnemies);
        
        
        float playerDistance = Vector3.Distance(player.position, transform.position);

        if (playerDistance <= 10f)
        {
            agent.SetDestination(enemy.position);
            attackTimer += Time.deltaTime; // Increment the timer

            // Attack only if the timer exceeds the attack interval
            if (attackTimer >= attackInterval)
            {
                Attack();
                attackTimer = 0f; // Reset the timer after attacking
            }
        }
        else
        {
            agent.SetDestination(player.position);
        }
        
        if (agent.velocity.magnitude < 0.01f)
        {
            animator.SetBool("isStop", true);
            Rotate(player.eulerAngles);
        }
        else
        {
            animator.SetBool("isStop", false);
            
        }

    }
    
    private void Rotate(Vector3 targetEulerAngles)
    {
        Quaternion targetRotation = Quaternion.Euler(targetEulerAngles);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void Attack()
    {
        spawnerPos.LookAt(enemy.position);
        for (int i = 0; i < bulletPerShot; i++)
        {
            SpawnBullet(new Vector3(0f,0f,0f), new Vector3(bulletSize, bulletSize, bulletSize));
            SpawnBullet(new Vector3(0.015f,0.015f,0f), new Vector3(bulletSize, bulletSize, bulletSize));
            SpawnBullet(new Vector3(-0.015f,-0.015f,0f), new Vector3(bulletSize, bulletSize, bulletSize));
            SpawnBullet(new Vector3(-0.015f,0.015f,0f), new Vector3(bulletSize, bulletSize, bulletSize));
        }
    }
    
    private void SpawnBullet(Vector3 offset, Vector3 scale)
    {
        GameObject curBullet = Instantiate(bullet, spawnerPos.position+offset, spawnerPos.rotation);
        curBullet.transform.localScale = scale;
        Rigidbody rb = curBullet.GetComponent<Rigidbody>();
        rb.AddForce(spawnerPos.forward * bulletVelocity, ForceMode.Impulse);
        // Vector3 offsetForward = spawnerPos.forward + new Vector3(offset, 0f, 0f); // Adjust offsetX as needed
        // rb.AddForce(offsetForward * bulletVelocity, ForceMode.Impulse);
    }

    private void Die()
    {
        
    }
    
    private Transform FindNearestEnemy(GameObject[][] allEnemies)
    {
        float minDistance = Mathf.Infinity;
        Transform nearest = null;

        foreach (GameObject[] enemyTypes in allEnemies)
        {
            foreach (GameObject enemyType in enemyTypes)
            {
                float distance = Vector3.Distance(transform.position, enemyType.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearest = enemyType.transform;
                }
            }
        }

        return nearest;
    }
}
