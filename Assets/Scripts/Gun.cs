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
        if(mouse == null) return; 

        if(mouse.leftButton.isPressed) {
            Fire();
        }
    }


    void Fire() {
        if(!onCooldown) {
            Rigidbody bullet = Instantiate(bulletPrefab, bulSpawn.position, bulSpawn.rotation);
            bullet.AddRelativeForce(Vector3.forward * 30, ForceMode.Impulse);
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown() {
        onCooldown = true;
        yield return new WaitForSeconds(.2f);
        onCooldown = false;
    }
}
