using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class SpawnedEnemy : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;
    
    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        agent.destination = player.GetComponent<Transform>().position;
    }

}
