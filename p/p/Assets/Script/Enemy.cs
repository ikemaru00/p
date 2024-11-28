using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Header("弾オブジェクト")]
    protected GameObject[] _bullet;
    [SerializeField, Header("弾を発射する時間")]
    protected float _shootTime;
    [SerializeField, Header("体力")]
    private int _hp;
    [SerializeField, Header("移動速度")]
    private float _moveSpeed;
    [SerializeField, Header("ダメージエフェクトの時間")]
    private float _damageEffectTime;
    [SerializeField, Header("ダメージ時の画像")]
    private Sprite _damageSprite;


    protected GameObject _player;
    protected Rigidbody2D _rigid;
    protected float _shootCount;
    protected bool _bAttack;

    private SpriteRenderer _spriteRenderer;
    private Sprite _defaultSprite;


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
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultSprite = _spriteRenderer.sprite; 
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
            StartCoroutine(_Damage());
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
        if (Camera.current.name == "Main Camera")
        {
            _bAttack = true;
        }
    }
    private IEnumerator _Damage()
    {
        _spriteRenderer.sprite = _damageSprite;
        yield return new WaitForSeconds(_damageEffectTime);
        _spriteRenderer.sprite = _defaultSprite;
    }

}
