using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class SpawnedEnemy : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;
    private Vector3 distance;
    
    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        agent.destination = player.GetComponent<Transform>().position;
    }

}
