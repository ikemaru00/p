using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoarText : MonoBehaviour
{
    public  Text scoreText; // UI��Text�R���|�[�l���g���A�^�b�`����
    

  
    public void Start()
    {
        int loadedScore = PlayerPrefs.GetInt("Score", 0);

        scoreText.text = "Score: " + loadedScore;
        
    }

    private void Update()
    {
        // �X�R�A����ʂɕ\��
        scoreText.text = "Score: " + ScoreScript.Instance.score;
    }
   
}