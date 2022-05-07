using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 10;
    public string thisObj;

    void Start() {
        thisObj = this.gameObject.tag;
    }

    void OnCollisionEnter(Collision other) {
        
        if(thisObj == "Enemy"){
            if(other.gameObject.tag == "Bullet"){
                Destroy(other.gameObject);
                TakeDamage();
            }
        }

        if(thisObj == "Player"){
            if(other.gameObject.tag == "Melee"){
                TakeDamage();
            }

            // when bullet colides with object
            if(other.gameObject.tag == "Bullet"){
                Destroy(other.gameObject);
                CollectAmmo();
            }
        }
    }


    void TakeDamage(){
        health -= 2;

        if(health <= 0){
            Destroy(this.gameObject);
        }
    }

    void CollectAmmo(){

    }

}
