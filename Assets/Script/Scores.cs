using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Scores : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    public static int scoreValue;
    public static int tempScores = 50;
    private int nextScene;
    
    void Start()
    {
       scoreValue = PersistentData.Instance.GetScore();
       scoreTxt = GetComponent<TextMeshProUGUI>();
       nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void Update()
    {
        scoreTxt.text = "Score: " + scoreValue;
       if(scoreValue >= tempScores)
       {
           SceneManager.LoadScene(nextScene);
           tempScores += 50;
       }
       
    }
}
