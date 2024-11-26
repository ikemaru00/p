using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField,Header("移動速度")]
    private float _speed;
    [SerializeField, Header("弾オブジェクト")]
    private GameObject _bullet;
    [SerializeField, Header("弾を発射する時間")]
    private float _shootTime;
    [SerializeField, Header("体力")]
    private int _hp;
    [SerializeField, Header("点滅時間")]
    private float _damageTime;
    [SerializeField, Header("点滅周期")]
    private float _damageCycle;
    [SerializeField, Header("死亡エフェクト")]
    private GameObject _deadEffect;


    private Vector2 _inputVelocity;
    private Rigidbody2D _rigid;
    private SpriteRenderer _spriteRenderer;
    private GameManager _gameManager;
    private float _shootCount;
    private float _damageTimeCount;
    private bool _bDamege;


    // Start is called before the first frame update    void Start()
    void Start()
    {
        _inputVelocity = Vector2.zero;
        _rigid = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _gameManager = FindObjectOfType<GameManager>();
        _shootCount = 0;
        _damageTimeCount = 0;
        _bDamege = false;
        
    }
    // Update is called once per frame
    void Update()
    {
        _Move();
        _Shooting();
        _Damage();
    }
    private void _Move()
    {
        _rigid.velocity = _inputVelocity * _speed;
    }
    private void _Shooting()
    {
        _shootCount += Time.deltaTime;
        if (_shootCount < _shootTime) return;

        GameObject bulletObj = Instantiate(_bullet);
        bulletObj.transform.position = transform.position + new Vector3(0f, transform.lossyScale.y/2.0f,0f);
        _shootCount = 0.0f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Enemy")
        {
            if(! _bDamege)
            {
                _hp -= 1;
                _bDamege = true;
                if (_hp <= 0)
                {
                    Destroy(gameObject);
                    Instantiate(_deadEffect, transform.position, Quaternion.identity);
                    _gameManager.DeadEffect();
                }
            }
         
        }
    }

    private void _Damage()
    {
        if (!_bDamege) return;

        _damageTimeCount += Time.deltaTime;

        float value = Mathf.Repeat(_damageTimeCount, _damageCycle);
        _spriteRenderer.enabled = value >= _damageCycle * 0.5f;

        if(_damageTimeCount >= _damageTime)
        {
            _damageTimeCount = 0;
            _spriteRenderer.enabled = true;
            _bDamege = false;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _inputVelocity = context.ReadValue<Vector2>();        
    }

    public int GetHP()
    {
        return _hp;
    }

    public bool IsDamage()
    {
        return _bDamege;
    }
}
