using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPIcon : MonoBehaviour
{
    [SerializeField, Header("HP�A�C�R��")]
    private GameObject _hpIcon;

    private Player _player;
    private int _beforeHP;
    private List<GameObject> _hpIconList;


    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _beforeHP = _player.GetHP();
        _hpIconList = new List<GameObject>();
        _CreatHPIcon();

    }

    private void _CreatHPIcon()
    {
        for(int i = 0;i < _player.GetHP(); i++)
        {
            GameObject icon = Instantiate(_hpIcon);
            icon.transform.SetParent(transform);
            _hpIconList.Add(icon);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _ShowHPIcon();
    }

    private void _ShowHPIcon()
    {
        if (_beforeHP == _player.GetHP()) return;

        for(int i = 0;i< _hpIconList.Count;i++)
        {
            _hpIconList[i].SetActive(i < _player.GetHP());
        }
        _beforeHP = _player.GetHP();
    }
}
