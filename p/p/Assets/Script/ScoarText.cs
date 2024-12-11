using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoarText : MonoBehaviour
{
    public  Text scoreText; // UIのTextコンポーネントをアタッチする
    

  
    public void Start()
    {
        int loadedScore = PlayerPrefs.GetInt("Score", 0);

        scoreText.text = "Score: " + loadedScore;
        
    }

    private void Update()
    {
        // スコアを画面に表示
        scoreText.text = "Score: " + ScoreScript.Instance.score;
    }
   
}