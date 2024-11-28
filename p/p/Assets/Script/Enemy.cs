using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Header("�e�I�u�W�F�N�g")]
    protected GameObject[] _bullet;
    [SerializeField, Header("�e�𔭎˂��鎞��")]
    protected float _shootTime;
    [SerializeField, Header("�̗�")]
    private int _hp;
    [SerializeField, Header("�ړ����x")]
    private float _moveSpeed;


    protected GameObject _player;
    protected Rigidbody2D _rigid;
    protected float _shootCount;
    protected bool _bAttack;


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
        _Initialize();
    }
    protected virtual void _Initialize()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _Attack();
    }
   
    protected virtual void _Attack()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _hp -= collision.gameObject.GetComponent<Bulet>().GetPower();
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    protected virtual void _Move()
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
