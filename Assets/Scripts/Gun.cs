using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{

    // public enum elements {Fire, Ice, Earth, Wind};
    // public elements elType = elements.Fire;

    // public string gunName = "Gun";
    // public int damage = 2;
    // public float rateOfFire = 0.5f;

    public Rigidbody bulletPrefab;
    public Transform bulSpawn;
    public bool onCooldown;

    public int magSize = 10;
    public int mag = 10;
    public int ammo = 30;

    // [Header("Randomization")]
    // public List<string> names;
    // public Vector2 damageRange;
    // public Vector2 rateOfFireRange;

    // private TextMeshPro nameText;


    void Start() {
        // nameText = transform.GetChild(1).GetComponent<TextMeshPro>();
    }

    // public void Randomize() {
    //     name = names[(int)elType];
    //     nameText.text = name;
    //     damage = (int)Random.Range(damageRange.x, damageRange.y);
    //     rateOfFire = Random.Range(rateOfFireRange.x, rateOfFireRange.y);
    // }


    // Update is called once per frame
    void Update()
    {
        
        var mouse = Mouse.current;
        var keyboard = Keyboard.current;

        if(mouse == null && keyboard == null) return;

        if(mouse.leftButton.isPressed) {
            Fire();
        }


        if(keyboard.rKey.wasPressedThisFrame) {
            Reload();
        }
        
    }


    void Fire() {
        if(!onCooldown) {
            if (mag > 0) {
                    mag -= 1;
                    Rigidbody bullet = Instantiate(bulletPrefab, bulSpawn.position, bulSpawn.rotation);
                    bullet.transform.Translate(0,0,1);
                    bullet.AddRelativeForce(Vector3.forward * 30, ForceMode.Impulse);

                    StartCoroutine(Cooldown());
            }
        }
    }

    void Reload() {
        if (mag == magSize) {
            Debug.Log("mag is already full.");
            return;
        }

        if(ammo + mag >= magSize) {
            ammo -= magSize - mag;
            mag = magSize;
        } else if (ammo > 0) { 
            mag = ammo + mag;
            ammo = 0;
        } else {
            Debug.Log("No ammo to reload!");
        }
    }

    public void GetAmmo() {
        ammo += 30;
    }

    IEnumerator Cooldown() {
        onCooldown = true;
        yield return new WaitForSeconds(.2f);
        onCooldown = false;
    }
}
