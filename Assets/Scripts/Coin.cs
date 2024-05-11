using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Timeline;

public class Coin : MonoBehaviour
{
    public NavMeshAgent coinAgent;
    public Transform coin;
    public AudioClip clinkSound;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(coin.position, player.position) < 2.5)
        {
            coinAgent.destination = player.position;
        }
        Debug.Log((Vector3.Distance(coin.position, player.position)));
        
        if(Vector3.Distance(coin.position, player.position) < 1.2){
            Destroy(gameObject, 0f);
            GameStateManager.Instance.AddCoin(1);
            //clinkSound.Play();
        }
    }
}
