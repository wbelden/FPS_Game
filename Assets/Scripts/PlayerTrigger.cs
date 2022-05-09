using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public Gun gun;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Ammo Pickup")) {
            // call the gun.GetAmmo() function
            gun.GetAmmo();
            Destroy(other.gameObject);
        }
    }
}
