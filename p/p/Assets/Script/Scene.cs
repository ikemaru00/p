using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
  public void Scene_button()
    {
        SceneManager.LoadScene("Stage");
        
    }
    public void Scene_Taitle()
    {
        SceneManager.LoadScene("taitle");

    }
}
