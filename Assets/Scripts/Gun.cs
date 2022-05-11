using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{

    public enum elements {Fire, Ice, Earth, Wind};
    public elements elType = elements.Fire;

    public string gunName = "Gun";
    public int damage = 2;
    public float rateOfFire = 0.5f;

    public Rigidbody bulletPrefab;
    public Transform bulSpawn;
    public bool onCooldown;

    public int magSize = 10;
    public int mag = 10;
    public int ammo = 30;

    [Header("Randomization")]
    public List<string> names;
    public Vector2 damageRange;
    public Vector2 rateOfFireRange;

    public TextMeshPro nameText;

    private Rigidbody rb;

    void Start() {
        rb = this.GetComponent<Rigidbody>();
    }

    public void Randomize() {
        name = names[(int)Random.Range(0, 2)];
        nameText.text = name;
        damage = (int)Random.Range(damageRange.x, damageRange.y);
        rateOfFire = Random.Range(rateOfFireRange.x, rateOfFireRange.y);
    }

    public void Fire() {
        if(!onCooldown) {
            if (mag > 0) {
                    mag -= 1;
                    Rigidbody bullet = Instantiate(bulletPrefab, bulSpawn.position, bulSpawn.rotation);
                    bullet.GetComponent<bullet>().damage = this.damage;
                    bullet.transform.Translate(0,0,1);
                    bullet.AddRelativeForce(Vector3.forward * 30, ForceMode.Impulse);

                    StartCoroutine(Cooldown());
            }
        }
    }

    public void Reload() {
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
        yield return new WaitForSeconds(rateOfFire);
        onCooldown = false;
    }

    public void Pickup(Transform hand) {
        this.transform.SetParent(hand);
        rb.isKinematic = true;
        this.transform.position = hand.position;
        this.transform.rotation = hand.rotation;
    }

    public void Drop() {
        this.transform.SetParent(null);
        this.transform.Translate(Vector3.forward*2);
        rb.isKinematic = false;
        rb.AddRelativeForce(Vector3.forward * 5, ForceMode.Impulse);
    }
}
