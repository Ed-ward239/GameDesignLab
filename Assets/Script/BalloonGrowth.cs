using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonGrowth : MonoBehaviour
{
    public float timer = 0f;
    public float growTime = 6f;
    public float maxSize = 2f;
    public bool isMaxSize = false;
    public GameObject popEffect;
    public AudioClip audioPlayer;
    [SerializeField] int damage = 5;

    void Start()
    {
       if(isMaxSize == false){
           StartCoroutine(Grow());
       } 
    }

    private IEnumerator Grow()
    {
        Vector2 startScale = transform.localScale;
        Vector2 maxScale = new Vector2(maxSize, maxSize);

        do
        {
            transform.localScale = Vector2.Lerp(startScale, maxScale, timer / growTime);
            timer += Time.deltaTime;
            yield return null;

        } while (timer < growTime);

        isMaxSize = true;
        if(isMaxSize == true)
        {
            PersistentData.Instance.SetScore(Scores.scoreValue -= damage);
            Instantiate(popEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint (audioPlayer, transform.position);
        }
    }
}