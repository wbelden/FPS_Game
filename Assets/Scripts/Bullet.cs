using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public int damage = 2;
    
    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Environment")){
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
