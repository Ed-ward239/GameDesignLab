using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distraction : MonoBehaviour
{
    public int health = 50;
    public GameObject popEffect;
    public AudioClip audioPlayer;

    public void TakeDamage (int damage)
    {
        health -= damage;
        if (health <= 0){
            Die();
        }
    }

    void Die ()
    {     
        Instantiate(popEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
