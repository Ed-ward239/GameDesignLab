using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    public float speed = 5f;
    bool moveLR = true;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(moveLR){
            moveballonright(); 
        }
        if(!moveLR){
            moveballonleft();
        }
        if(transform.position.x >= 7f){
            moveLR = false;
            spriteRenderer.flipX = true;
        }
        if(transform.position.x <= -7f){
            moveLR = true;
            spriteRenderer.flipX = false;
        }
    }

   void moveballonright(){
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    void moveballonleft(){
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
