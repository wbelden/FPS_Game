using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 10;

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Bullet")){
            Destroy(other.gameObject);
            health -= 2;

            if(health <= 0){
                Destroy(this.gameObject);
            }
        }
        
    }

}
