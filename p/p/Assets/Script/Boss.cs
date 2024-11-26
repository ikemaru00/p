using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField, Header("�ړ��͈�")]
    private float _limitPoyY;
    [SerializeField, Header("�ʏ�U����")]
    private int _normalAttackCount;

    enum AttackMode
    {
        Normal,
        Ougi,
    }

    private int _currentNormalAttackCount;
    private AttackMode _attackMode;

    protected override void _Initialize()
    {
        _currentNormalAttackCount = 0;
        _attackMode = AttackMode.Normal;
    }

    protected override void _Move()
    {
        if(transform.position.y <= _limitPoyY)
        {
            _rigid.velocity = Vector2.zero;
            _bAttack = true;
            return;
        }
        base._Move();
        _bAttack = false;
    }

    protected override void _Attack()
    {
       switch (_attackMode)
        {
            case AttackMode.Normal:_NormalShooting(); break;
            case AttackMode.Ougi: break;
        }

    }

    private void _NormalShooting()
    {
        _shootCount += Time.deltaTime;
        if (_shootCount < _shootTime) return;

        GameObject bulletObj = Instantiate(_bullet[0]);
        bulletObj.transform.position = transform.position;
        bulletObj.transform.rotation = Quaternion.FromToRotation(transform.up, Vector2.down);


        _shootCount = 0f;
        _currentNormalAttackCount++;

        if(_currentNormalAttackCount >= _normalAttackCount)
        {
            _attackMode = AttackMode.Ougi;
            _currentNormalAttackCount = 0;
        }

    }
}
