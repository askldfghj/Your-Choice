using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public List<ItemIconCtrl> _equipInventory;
    public GameObject _myBags;
    public ItemIconCtrl[] _myBagInventory;

    void Awake()
    {
        _myBagInventory = _myBags.GetComponentsInChildren<ItemIconCtrl>();
    }

    public void ApplyEquipItems()
    {
        PlayerObj._current._playerInfo._equipItem["wep"] = _equipInventory[0]._item;
        PlayerObj._current.ApplyWeapon();
        PlayerObj._current._playerInfo._equipItem["arm"] = _equipInventory[1]._item;
        PlayerObj._current.ApplyArmor();
        PlayerObj._current._playerInfo._equipItem["acc"] = _equipInventory[2]._item;
        PlayerObj._current.ApplyAccessory();
    }
}
