using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField,Header("�ړ����x")]
    private float _speed;
    [SerializeField, Header("�e�I�u�W�F�N�g")]
    private GameObject _bullet;
    [SerializeField, Header("�e�𔭎˂��鎞��")]
    private float _shootTime;

    private Vector2 _inputVelocity;
    private Rigidbody2D _rigid;
    private float _shootCount;


    // Start is called before the first frame update    void Start()
    void Start()
    {
        _inputVelocity = Vector2.zero;
        _rigid = GetComponent<Rigidbody2D>();
        _shootCount = 0;
    }
    // Update is called once per frame
    void Update()
    {
        _Move();
        _Shooting();
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
    public void OnMove(InputAction.CallbackContext context)
    {
        _inputVelocity = context.ReadValue<Vector2>();        
    }
}
