using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameClear : MonoBehaviour
{
    private GameObject[] enemyBox;
    void Update()
    {
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");

        //print("ìGÇÃêîÅF" + enemyBox.Length);

        if (enemyBox.Length == 0)
        {
            PlayerPrefs.Save();
            StartCoroutine(Defeat());
        }

    }
    IEnumerator Defeat()
    {
       // Debug.Log("ì¸Ç¡ÇΩ");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Clear");
    }
}