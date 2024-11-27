using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField, Header("�ړ��͈�")]
    private float _limitPoyY;
    [SerializeField, Header("�ʏ�U����")]
    private int _normalAttackCount;
    [SerializeField, Header("��e�̒e��")]
    private int _ougiBulleNum;
    [SerializeField,Header("��e�̊p�x")]
    private float _ougiAngle;
    [SerializeField, Header("��e�̍U����")]
    private int _ougiAttackCount;
    [SerializeField, Header("�W�O�U�O�e�U���̎���")]
    private float _LRAttackTime;
    [SerializeField, Header("�W�O�U�O�e�̊ԋ�")]
    private float _LRShootTime;
    [SerializeField, Header("�W�O�U�O�̕�")]
    private float _LRRange;
    [SerializeField, Header("�W�O�U�O�̑��x")]
    private float _LRSpeed;
    [SerializeField,Header("�~�`�̒e��")]
    private int  _circleBulletNum;
    [SerializeField, Header("�~�`�U���̎���")]
    private float _circleShootTime;
    [SerializeField, Header("�~�`�ɒe�𔭎˂���ԕ�")]
    private float _circleBulletTime;

    enum AttackMode
    {
        Normal,
        Ougi,
        LeftRight,
        Circle,
    }

    private int _currentAttackCount;
    private AttackMode _attackMode;
    private float _rotateZ;
    private float _LRAttackCount;
    private float _circleShootCount;

    protected override void _Initialize()
    {
        _currentAttackCount = 0;
        _attackMode = AttackMode.Normal;
        _rotateZ = 0f;
        _LRAttackCount = 0f;
        _circleShootCount = 0;
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
            case AttackMode.Ougi: _OugiShooting(); break;
            case AttackMode.LeftRight:_LeftRightShooting(); break;
            case AttackMode.Circle:_CircleShooting(); break;

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
        _currentAttackCount++;

        if(_currentAttackCount >= _normalAttackCount)
        {
            _attackMode = AttackMode.Ougi;
            _currentAttackCount = 0;
        }

    }
    private void _OugiShooting()
    {
        _shootCount += Time.deltaTime;
        if (_shootCount < _shootTime) return;

        for(int i=0; i < _ougiBulleNum;i++)
        {
            float angleRange = Mathf.Deg2Rad * _ougiAngle;
            float theta = angleRange / (_ougiBulleNum - 1) * i - Mathf.Deg2Rad * (90f + _ougiAngle / 2f);
            GameObject bullet = Instantiate(_bullet[1]);
            bullet.transform.position = transform.position;
            Vector3 dir = transform.position + new Vector3(Mathf.Cos(theta), Mathf.Sin(theta)) - transform.position;
            bullet.transform.rotation = Quaternion.FromToRotation(transform.up, dir);
        }

        _shootCount = 0f;
        _currentAttackCount++;

        if (_currentAttackCount >= _ougiAttackCount)
        {
            _attackMode = AttackMode.LeftRight;
            _currentAttackCount = 0;
        }
    }

    private void _LeftRightShooting()
    {
        _LRAttackCount += Time.deltaTime;
        if(_LRAttackCount >= _LRAttackTime)
        {
            _shootCount = 0f;
            _LRAttackCount = 0;
            _attackMode = AttackMode.Circle;
        }


        _shootCount += Time.deltaTime;
        if (_shootCount < _LRShootTime) return;

        _rotateZ += _LRSpeed;
        if(_rotateZ > _LRRange)
        {
            _LRSpeed *= -1f;
            _rotateZ = _LRRange;
        }
        else if(_rotateZ < -_LRRange)
        {
            _LRSpeed *= -1f;
            _rotateZ = -_LRRange;
        }

        GameObject bullet = Instantiate(_bullet[2]);
        bullet.transform.position = transform.position;
        bullet.transform.eulerAngles = new Vector3(0f, 0f, -180f + _rotateZ);

        _shootCount = 0f;
    }
    private void _CircleShooting()
    {

        _circleShootCount += Time.deltaTime;
        if (_circleShootCount >= _circleShootTime)
        {
            _shootCount = 0f;
            _circleShootCount = 0f;
            _attackMode = AttackMode.Normal;
        }

        _shootCount += Time.deltaTime;
        if (_shootCount < _circleBulletTime) return;

        for (int i = 0; i < _circleBulletNum;i++)
        {
            float angleRange = Mathf.Deg2Rad * 360f;
            float theta = angleRange / (_circleBulletNum - 1) * i - Mathf.Deg2Rad * (90f + 360f / 2f);
            GameObject bullet = Instantiate(_bullet[3]);
            bullet.transform.position = transform.position;
            Vector3 dir = transform.position + new Vector3(Mathf.Cos(theta), Mathf.Sin(theta)) - transform.position;
            bullet.transform.rotation = Quaternion.FromToRotation(transform.up, dir);

        }

        _shootCount = 0f;
    }

}
