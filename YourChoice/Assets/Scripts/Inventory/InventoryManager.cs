using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public GameObject _myEquips;
    //public List<ItemIconCtrl> _equipInventory;
    public GameObject _myBags;
    public ItemIconCtrl[] _myEquipInventory;
    public ItemIconCtrl[] _myBagInventory;

    BoxCollider[] _myEquipColliders;
    BoxCollider[] _myBagColliders;

    void Awake()
    {
        _myEquipInventory = _myEquips.GetComponentsInChildren<ItemIconCtrl>();
        _myBagInventory = _myBags.GetComponentsInChildren<ItemIconCtrl>();

        _myEquipColliders = _myEquips.GetComponentsInChildren<BoxCollider>();
        _myBagColliders = _myBags.GetComponentsInChildren<BoxCollider>();
    }

    public void ApplyEquipItems()
    {
        PlayerObj._current._playerInfo._equipItem["wep"] = _myEquipInventory[0]._item;
        PlayerObj._current.ApplyWeapon();
        PlayerObj._current._playerInfo._equipItem["arm"] = _myEquipInventory[1]._item;
        PlayerObj._current.ApplyArmor();
        PlayerObj._current._playerInfo._equipItem["acc"] = _myEquipInventory[2]._item;
        PlayerObj._current.ApplyAccessory();
    }

    public void InventoryColliderShutDown()
    {
        int i;
        for (i = 0; i < _myEquipColliders.Length; i++)
        {
            _myEquipColliders[i].enabled = false;
        }
        for (i = 0; i < _myBagColliders.Length; i++)
        {
            _myBagColliders[i].enabled = false;
        }
    }

    public void InventoryColliderShutOn()
    {
        int i;
        for (i = 0; i < _myEquipColliders.Length; i++)
        {
            _myEquipColliders[i].enabled = true;
        }
        for (i = 0; i < _myBagColliders.Length; i++)
        {
            _myBagColliders[i].enabled = true;
        }
    }
}
