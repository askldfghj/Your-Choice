using UnityEngine;
using System.Collections;

public class ItemUseCtrl : MonoBehaviour
{
    public UseButton[] _btns;
    public InventoryManager _inven;

    bool[] _colliderEnables;

    ItemIconCtrl _target;

    void Awake()
    {
        _colliderEnables = new bool[_btns.Length];
    }

    void EquipItem()
    {
        switch (_target._item._itemType)
        {
            case "wep":
                _inven.EquipToWeapon(_target);
                break;
            case "arm":
                _inven.EquipToArmor(_target);
                break;
            case "acc":
                _inven.EquipToAccessory(_target);
                break;
            default:
                break;
        }

        WindowClose();
    }
    void UnEquipItem()
    {
        _inven.UnEquipItem(_target);
        WindowClose();
    }

    public void SetEquipBtn(ItemIconCtrl target)
    {
        _target = target;
        _btns[0]._label.text = "장착";
        _btns[0]._message.functionName = "EquipItem";
        _btns[1]._message.functionName = "WindowClose";
    }
    public void SetUnEquipBtn(ItemIconCtrl target)
    {
        _target = target;
        _btns[0]._label.text = "탈착";
        _btns[0]._message.functionName = "UnEquipItem";
        _btns[1]._message.functionName = "WindowClose";
    }

    void WindowClose()
    {
        gameObject.SetActive(false);
    }

    public void PauseColliders()
    {
        if (gameObject.activeInHierarchy)
        {
            for (int i = 0; i < _btns.Length; i++)
            {
                _colliderEnables[i] = _btns[i]._collider.enabled;
                _btns[i]._collider.enabled = false;
            }
        }
    }
    public void ResumeColliders()
    {
        if (gameObject.activeInHierarchy)
        {
            for (int i = 0; i < _btns.Length; i++)
            {
                _btns[i]._collider.enabled = _colliderEnables[i];
            }
        }
    }

}

[System.Serializable]
public struct UseButton
{
    public BoxCollider _collider;
    public UIButtonMessage _message;
    public UILabel _label;
}
