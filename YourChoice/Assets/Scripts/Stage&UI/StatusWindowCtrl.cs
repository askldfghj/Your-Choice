using UnityEngine;
using System.Collections;

public class StatusWindowCtrl : MonoBehaviour
{
    public StatusStructs _structs;

    bool[] _colliderEnables;

    void Awake()
    {
        _colliderEnables = new bool[_structs.colliders.Length];
    }

    void OnEnable()
    {
        SetLabel();
    }

    public void SetLabel()
    {
        _structs.nameLabel.text = "이름: " + PlayerObj._current._playerInfo._name;
        _structs.strLabel.text = "힘: " + PlayerObj._current._playerInfo._str;
        _structs.dexLabel.text = "민첩: " + PlayerObj._current._playerInfo._dex;
        _structs.intelLabel.text = "지능: " + PlayerObj._current._playerInfo._int;
        _structs.wepLabel.text = "공격력: " + PlayerObj._current._playerInfo._wep;
        _structs.armLabel.text = "방어력: " + PlayerObj._current._playerInfo._arm;
        _structs.levelPLabel.text = PlayerObj._current._playerInfo._levelPoint.ToString();
    }

    public void PauseColliders()
    {
        if (gameObject.activeInHierarchy)
        {
            for (int i = 0; i < _structs.colliders.Length; i++)
            {
                _colliderEnables[i] = _structs.colliders[i].enabled;
                _structs.colliders[i].enabled = false;
            }
        }
    }
    public void ResumeColliders()
    {
        if (gameObject.activeInHierarchy)
        {
            for (int i = 0; i < _structs.colliders.Length; i++)
            {
                _structs.colliders[i].enabled = _colliderEnables[i];
            }
        }
    }

    public void UpStr()
    {
        if (PlayerObj._current._playerInfo._levelPoint > 0)
        {
            PlayerObj._current._playerInfo._str++;
            PlayerObj._current._playerInfo._levelPoint--;
        }
        SetLabel();
    }
    public void UpDex()
    {
        if (PlayerObj._current._playerInfo._levelPoint > 0)
        {
            PlayerObj._current._playerInfo._dex++;
            PlayerObj._current._playerInfo._levelPoint--;
        }
        SetLabel();
    }
    public void UpInt()
    {
        if (PlayerObj._current._playerInfo._levelPoint > 0)
        {
            PlayerObj._current._playerInfo._int++;
            PlayerObj._current._playerInfo._levelPoint--;
        }
        SetLabel();
    }
}
[System.Serializable]
public struct StatusStructs
{
    public UILabel nameLabel;
    public UILabel strLabel;
    public UILabel dexLabel;
    public UILabel intelLabel;
    public UILabel wepLabel;
    public UILabel armLabel;
    public UILabel expLabel;
    public UILabel levelPLabel;

    public BoxCollider[] colliders;
}