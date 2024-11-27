using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("�x���Ȃ鎞��")]
    private float _deadEffectTimeScale;
    [SerializeField, Header("���Ԃ����ɖ߂�����")]
    private float _desaEffectTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeadEffect()
    {
        StartCoroutine(Slow());
    }
    IEnumerator Slow()
    {
        Time.timeScale = _deadEffectTimeScale;

        yield return new WaitForSecondsRealtime(_desaEffectTime);

            Time.timeScale = 1.0f;
    }
}
