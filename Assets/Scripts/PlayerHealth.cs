using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Melee") ){
            health -= 2;
            if(health <= 0){
                Application.LoadLevel(0);
            }
        }
    }
}
