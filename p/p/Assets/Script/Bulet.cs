using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{
    [SerializeField,Header("�e��̑��x")]
    private float _speed;
    [SerializeField, Header("�e�̈З�")]
    private int _speer;

    private Rigidbody2D _rigid;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void _Move()
    {
        _rigid.velocity = transform.up * _speed;
    }
}