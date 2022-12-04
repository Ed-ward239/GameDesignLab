using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shooting;
    public GameObject weapon;
    public AudioClip audioPlayer; 

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            shoot();
        }
    void shoot () 
    {
        AudioSource.PlayClipAtPoint (audioPlayer, transform.position);
        Instantiate(weapon, shooting.position, shooting.rotation);
    }
    }
}