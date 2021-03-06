﻿using UnityEngine;
using System.Collections;

public class PlayerObj : MonoBehaviour
{
    public static PlayerObj _current;
    public PlayerInfo _playerInfo;
    public InventoryManager _myInven;
    Vector3 _originPos;

    void Awake()
    {
        _originPos = transform.localPosition;
        _current = this;

        _playerInfo = new PlayerInfo("player", 30, 5, 5, 5, 0, 0);
        _playerInfo._levelPoint = 10;
    }

    public void ApplyWeapon()
    {
        _playerInfo._wep = _myInven._myEquipInventory[0]._item._wep;
    }

    public void ApplyArmor()
    {
        _playerInfo._arm = _myInven._myEquipInventory[1]._item._arm;
    }

    public void ApplyAccessory()
    {

    }

    public void SelectApplyEquipItem(string str)
    {
        switch (str)
        {
            case "wep":
                ApplyWeapon();
                break;
            case "arm":
                ApplyArmor();
                break;
            case "acc":
                break;
            default:
                break;
        }
    }

    public void Damaged(int dam)
    {
        _playerInfo._health -= dam;
    }

    public void GetExperience(int exp)
    {
        _playerInfo._exp += exp;
        if (_playerInfo._exp > 100)
        {
            _playerInfo._exp =- 100;
            LevelUp();
        }
    }

    void LevelUp()
    {
        _playerInfo._levelPoint += 5;
    }

    public void ObjShake()
    {
        transform.localPosition = _originPos;
        StopCoroutine("Shake");
        StartCoroutine("Shake");
    }

    IEnumerator Shake()
    {
        // How long the object should shake for.
        float shake = 0.3f;

        // Amplitude of the shake. A larger value shakes the camera harder.
        float shakeAmount = 30f;
        float decreaseFactor = 1.0f;
        while (shake > 0)
        {
            transform.localPosition = _originPos + Random.insideUnitSphere * shakeAmount;

            shake -= Time.deltaTime * decreaseFactor;
            yield return null;
        }
        shake = 0f;
        transform.localPosition = _originPos;
    }
}
