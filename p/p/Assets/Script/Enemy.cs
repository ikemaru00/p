using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    private int scoreValue = 10; // ���̓G��|�����Ƃ��̃X�R�A
    private int scoreBoss = 100; // ���̓G��|�����Ƃ��̃X�R�A

    [SerializeField, Header("�e�I�u�W�F�N�g")]
    protected GameObject[] _bullet;
    [SerializeField, Header("�e�𔭎˂��鎞��")]
    protected float _shootTime;
    [SerializeField, Header("�̗�")]
    private int _hp;
    [SerializeField, Header("�ړ����x")]
    private float _moveSpeed;
    [SerializeField, Header("�_���[�W�G�t�F�N�g�̎���")]
    private float _damageEffectTime;
    [SerializeField, Header("�_���[�W���̉摜")]
    private Sprite _damageSprite;
    [SerializeField, Header("���S�G�t�F�N�g")]
    private GameObject _deadEffect;

    protected GameObject _player;
    protected Rigidbody2D _rigid;
    protected Vector2 _moveVec;
    protected float _shootCount;
    protected bool _bAttack;

    private SpriteRenderer _spriteRenderer;
    private Sprite _defaultSprite;

    [SerializeField, Header("�̗̓{�X")]
    private int _Bosshp;


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
        _moveVec = Vector2.down;
        _Initialize();
    }

    private GameObject[] enemyBox;
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
            _Bosshp-= collision.gameObject.GetComponent<Bulet>().GetPower();
            StartCoroutine(_Damage());
            if (_hp <= 0)
            {
                ScoreScript.Instance.AddScore(scoreValue);
                int currentScore = PlayerPrefs.GetInt("Score", 0);
                currentScore += scoreValue;
                PlayerPrefs.SetInt("Score", currentScore); // �X�R�A��ۑ�
                Destroy(gameObject);

            }

            else if(_Bosshp <= 0)
            { 
            
                ScoreScript.Instance.AddScore(scoreBoss);
                int BoosScoar = PlayerPrefs.GetInt("Score", 0);
                BoosScoar += scoreBoss;
                PlayerPrefs.SetInt("Score", BoosScoar); // �X�R�A��ۑ�       Destroy(gameObject);
                Destroy(gameObject);
                

            }

        }
    }
    protected virtual void _Move()
    {
        _rigid.velocity = _moveVec *  _moveSpeed;
    }
    private void OnWillRenderObject()
    {
        if (Camera.current.name == "Main Camera")
        {
            _bAttack = true;
        }
    }
    public IEnumerator _Damage()
    {
        _spriteRenderer.sprite = _damageSprite;
        yield return new WaitForSeconds(_damageEffectTime);
        _spriteRenderer.sprite = _defaultSprite;
    }

}
