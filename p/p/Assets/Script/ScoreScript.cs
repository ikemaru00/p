using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI�@�\�������Ƃ��ɒǋL����
public class ScoreScript : MonoBehaviour
{
    private int Score; //���_�̕ϐ�
    public Text ScoreText; //���_�̕����̕ϐ�

    // Start is called before the first frame update
    void Start()
    {
        Score = 0; //���_��0�ɂ���
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score:" + Score.ToString(); //ScoreText�̕�����Score:Score�̒l�ɂ���

        if (Input.GetKey(KeyCode.Space)) //�����A�X�y�[�X�L�[�������ꂽ��A
        {
            Score += 1000; //Score��1000���ς���
        }
    }
}