using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    Transform emitter;
    public Transform player;
    public float fieldOfView = 45;

    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        emitter = transform.GetChild(0);
        //rend = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 rayDirection = (player.position + Vector3.up) - emitter.position;

        float angle = Vector3.Angle(rayDirection, emitter.forward);
        //rend.material.color = Color.white;
        if(angle < fieldOfView){
            if(Physics.Raycast(emitter.position, rayDirection, out hit, fieldOfView)) {
                if(hit.collider.CompareTag("Player")){
                    Debug.DrawRay(emitter.position, rayDirection, Color.red);
                    rend.material.color = Color.red;
                } else {
                    Debug.DrawRay(emitter.position, rayDirection, Color.green);
                    rend.material.color = Color.green;
                }
            } else {
                
                //rend.material.color = Color.blue;
                rend.material.color = Color.Lerp(Color.red, Color.white, 5);
            }
        } else {
            //rend.material.color = Color.blue;
        }         
    }
}
