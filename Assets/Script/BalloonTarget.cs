using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonTarget : MonoBehaviour
{
    public int health = 20;
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
        PersistentData.Instance.SetScore(Scores.scoreValue += 10);
        Instantiate(popEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
