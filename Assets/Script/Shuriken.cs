using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public float speed = 50f;
    public int damage = 50;
    public Rigidbody2D rigidBody;
    
    void Start()
    {
        rigidBody.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        BalloonTarget balloonTarget = hitInfo.GetComponent<BalloonTarget>();
        if (balloonTarget != null){
            balloonTarget.TakeDamage(damage);
        }
        Destroy(gameObject);
 
        
        Distraction distraction = hitInfo.GetComponent<Distraction>();
        if (distraction != null){
            distraction.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
