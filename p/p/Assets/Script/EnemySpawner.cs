using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField, Header("敵のオブジェクト")]
    private GameObject[] _enemy;
    
    [SerializeField, Header("敵を生成する時間")]
    private float[] _spawnTime;

    public GameObject _EnemySpo;
    
    private float _spawnCount;
    private int _spawnNum;
    
    // Start is called before the first frame update
    void Start()
    {
       
        _spawnCount = 0.0f;
        _spawnNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (_spawnNum > 5)
        //{
        //    Debug.Log("時間");
        //    StartCoroutine(Defeat());
        //}
        _Spawn();
    }
    private void _Spawn()
    {
        if (_spawnNum > _enemy.Length - 1)return;
         
        _spawnCount += Time.deltaTime;
        if (_spawnCount >= _spawnTime[_spawnNum])
        {
            Debug.Log(_spawnNum);
            Instantiate(_enemy[_spawnNum]);
            _spawnNum++;
            _spawnCount = 0.0f;


            if(_spawnNum > 6)
            {
                StartCoroutine(Defeat());
                
                Destroy(_EnemySpo);
            }
        }

      
    }
    IEnumerator Defeat()
    {
        //Debug.Log("入った");
        yield return new WaitForSeconds(5.0f);
    }
}
