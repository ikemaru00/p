using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI�@�\�������Ƃ��ɒǋL����
public class ScoreScript : MonoBehaviour
{
    public static ScoreScript Instance;

    public int score = 0;

    private void Awake()
    {
        // �V���O���g���p�^�[���̐ݒ�
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �V�[�����܂����ł��폜����Ȃ�
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