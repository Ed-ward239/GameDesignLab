using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawn : MonoBehaviour
{
    [SerializeField] private GameObject balloonObj;
    [SerializeField] private GameObject distractorObj;

    [SerializeField] private float smallerInterval = 3.5f;
    [SerializeField] private float greaterInterval = 8f;

    void Start()
    {
        StartCoroutine(spawnBalloon(smallerInterval, balloonObj));
        StartCoroutine(spawnBalloon(greaterInterval, distractorObj));
    }

    private IEnumerator spawnBalloon(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-4f, 4f), Random.Range(-5f, 5f), 0), Quaternion.identity);
        StartCoroutine(spawnBalloon(interval, enemy));
    }
}
