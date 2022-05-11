using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTrigger : MonoBehaviour
{
    //public Gun gun;
    public Transform hand;
    Gun heldGun = null;

    void Update() {
        var mouse = Mouse.current;
        var keyboard = Keyboard.current;

        if(mouse == null && keyboard == null) return;

        if(mouse.leftButton.isPressed) {
            heldGun.Fire();
        }


        if(keyboard.rKey.wasPressedThisFrame) {
            heldGun.Reload();
        }
        
        if(keyboard.eKey.wasPressedThisFrame) { 
            heldGun.Drop();
            heldGun = null;
        } 
    }

    void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.CompareTag("Gun")) {
            if(heldGun == null) {
                heldGun = other.gameObject.GetComponent<Gun>();
                heldGun.Pickup(hand);
            }
        }

        if(other.gameObject.CompareTag("Ammo Pickup")) {
            // call the gun.GetAmmo() function
            heldGun.GetAmmo();
            Destroy(other.gameObject);
        }


    }
}
