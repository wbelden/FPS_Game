using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 10;
    int damage = 2;

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Bullet")){
            Destroy(other.gameObject);
            damage = other.gameObject.GetComponent<bullet>().damage;
            health -= damage;

            if(health <= 0){
                Destroy(this.gameObject);
            }
        }
        
    }

}
