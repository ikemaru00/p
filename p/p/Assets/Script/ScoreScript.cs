using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI機能を扱うときに追記する
public class ScoreScript : MonoBehaviour
{
    public static ScoreScript Instance;

    public int score = 0;

    private void Awake()
    {
        // シングルトンパターンの設定
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーンをまたいでも削除されない
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;
      //  Debug.Log("Current Score: " + score);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }
}