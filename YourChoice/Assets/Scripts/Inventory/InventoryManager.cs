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

    bool[] _myEquipColEnables;
    bool[] _myBagColEnables;

    void Awake()
    {
        _myEquipInventory = _myEquips.GetComponentsInChildren<ItemIconCtrl>();
        _myBagInventory = _myBags.GetComponentsInChildren<ItemIconCtrl>();

        _myEquipColliders = _myEquips.GetComponentsInChildren<BoxCollider>();
        _myBagColliders = _myBags.GetComponentsInChildren<BoxCollider>();

        _myEquipColEnables = new bool[_myEquipColliders.Length];
        _myBagColEnables = new bool[_myBagColliders.Length];
    }

    public void SwapInventory(ItemIconCtrl a, ItemIconCtrl b)
    {
        ItemObjInfo temp = a._item;
        a._item = b._item;
        b._item = temp;
    }

    public void EquipToWeapon(ItemIconCtrl targetItem)
    {
        ItemObjInfo temp = _myEquipInventory[0]._item;
        _myEquipInventory[0]._item = targetItem._item;
        targetItem._item = temp;

        bool isenable = _myEquipInventory[0]._sprite.enabled;
        targetItem._sprite.enabled = isenable;
        _myEquipInventory[0]._sprite.enabled = true;
    }
    public void EquipToArmor(ItemIconCtrl targetItem)
    {
        ItemObjInfo temp = _myEquipInventory[1]._item;
        _myEquipInventory[1]._item = targetItem._item;
        targetItem._item = temp;

        bool isenable = _myEquipInventory[1]._sprite.enabled;
        targetItem._sprite.enabled = isenable;
        _myEquipInventory[1]._sprite.enabled = true;
    }
    public void EquipToAccessory(ItemIconCtrl targetItem)
    {
        ItemObjInfo temp = _myEquipInventory[2]._item;
        _myEquipInventory[2]._item = targetItem._item;
        targetItem._item = temp;

        bool isenable = _myEquipInventory[2]._sprite.enabled;
        targetItem._sprite.enabled = isenable;
        _myEquipInventory[2]._sprite.enabled = true;
    }

    public void UnEquipItem(ItemIconCtrl targetItem)
    {
        int index = 0;
        while (index < _myBagInventory.Length)
        {
            if (!_myBagInventory[index]._sprite.enabled) break;
            index++;
        }
        if (index < _myBagInventory.Length)
        {
            _myBagInventory[index]._item = targetItem._item;
            _myBagInventory[index]._sprite.spriteName = _myBagInventory[index]._item._spriteName;
        }
        _myBagInventory[index]._sprite.enabled = true;
        targetItem._sprite.enabled = false;
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

    public void InventoryColliderPause()
    {
        int i;
        for (i = 0; i < _myEquipColliders.Length; i++)
        {
            _myEquipColEnables[i] = _myEquipColliders[i].enabled;
            _myEquipColliders[i].enabled = false;
        }
        for (i = 0; i < _myBagColliders.Length; i++)
        {
            _myBagColEnables[i] = _myBagColliders[i].enabled;
            _myBagColliders[i].enabled = false;
        }
    }
    public void InventoryColliderResume()
    {
        int i;
        for (i = 0; i < _myEquipColliders.Length; i++)
        {
            _myEquipColliders[i].enabled = _myEquipColEnables[i];
        }
        for (i = 0; i < _myBagColliders.Length; i++)
        {
            _myBagColliders[i].enabled = _myBagColEnables[i];
        }
    }
}
