using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Header("弾オブジェクト")]
    private GameObject _bullet;
    [SerializeField, Header("弾を発射する時間")]
    private float _shootTime;
    [SerializeField, Header("体力")]
    private int _hp;
    [SerializeField, Header("移動速度   ")]
    private float _moveSpeed;


    private GameObject _player;
    private Rigidbody2D _rigid;
    private float _shootCount;
    private bool _bAttack;


    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<Player>())
        {
            _player = FindObjectOfType<Player>().gameObject;
        }
        _shootCount = 0;
        _bAttack = false;
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Shooting();
        _Move();
    }
    private void _Shooting()
    {
        if (_player == null) return;

        _shootCount += Time.deltaTime;
        if (_shootCount < _shootTime) return;

        GameObject bulletObj = Instantiate(_bullet);
        bulletObj.transform.position = transform.position;
        Vector3 dir = _player.transform.position - transform.position;
        bulletObj.transform.rotation = Quaternion.FromToRotation(transform.up, dir);
        _shootCount = 0.0f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _hp -= 1;
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void _Move()
    {
        _rigid.velocity = Vector2.down *  _moveSpeed;
    }
    private void OnWillRenderObject()
    {
        if (Camera.current.name == "Main Camera") ;
        {
            _bAttack = true;
        }
    }
    

}
