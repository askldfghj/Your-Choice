using UnityEngine;
using System.Collections;

public class CursorCtrl : MonoBehaviour
{
    public UISprite _sprite;
    public Camera _uiCamera;
    public GameObject _itemDesc;
    public InventoryManager _invenManager;

    UISprite _target;
    ItemIconCtrl _targetInventory;
    ItemDescCtrl _itemDescCtrl;

    void Awake()
    {
        _itemDescCtrl = _itemDesc.GetComponent<ItemDescCtrl>();
    }

    void OnEnable()
    {
        _target = null;
        _itemDesc.SetActive(false);
    }

    public void PressCursor(ItemIconCtrl icon, Vector3 pos, string name)
    {
        _target = icon._sprite;
        _targetInventory = icon;
        pos.z = 0f;
        transform.position = pos;
        _sprite.enabled = true;
        _sprite.spriteName = name;
        _itemDesc.SetActive(false);
    }

    public void Drag()
    {
        Vector3 pos = Input.mousePosition;
        pos.x = Mathf.Clamp01(pos.x / Screen.width);
        pos.y = Mathf.Clamp01(pos.y / Screen.height);
        transform.position = _uiCamera.ViewportToWorldPoint(pos);
    }

    public void Drop()
    {
        Collider col = UICamera.lastHit.collider;

        if (col != null)
        {
            if (col.tag == "ItemSlot" || col.tag == "EquipSlot")
            {
                ItemIconCtrl colItem = col.GetComponent<ItemIconCtrl>();
                if (CheckSlotType(_targetInventory, colItem))
                {
                    //아이템 교체부분
                    _invenManager.SwapInventory(_targetInventory, colItem);

                    if (_targetInventory._InventoryName != "")
                    {
                        PlayerObj._current.SelectApplyEquipItem(_targetInventory._InventoryName);
                    }
                    else if (colItem._InventoryName != "")
                    {
                        PlayerObj._current.SelectApplyEquipItem(colItem._InventoryName);
                    }

                    UISprite spr = col.GetComponent<ItemIconCtrl>()._sprite;
                    if (spr.enabled)
                    {
                        _target.enabled = true;
                        _target.spriteName = spr.spriteName;
                    }
                    else
                    {
                        _target.enabled = false;
                        spr.enabled = true;
                    }
                    spr.spriteName = _sprite.spriteName;
                }
                else
                {
                    _target.enabled = true;
                }
            }
            else
            {
                _target.enabled = true;
            }
            _sprite.enabled = false;
        }
        else
        {
            _target.enabled = true;
            _sprite.enabled = false;
        }
        _target = null;
        _targetInventory = null;
    }

    public void ShowItemDesc(string name, string point, string stat)
    {
        _itemDesc.SetActive(true);
        Vector3 pos = Input.mousePosition;
        pos.x = Mathf.Clamp01(pos.x / Screen.width);
        pos.y = Mathf.Clamp01(pos.y / Screen.height);
        _itemDesc.transform.position = _uiCamera.ViewportToWorldPoint(pos);
        _itemDescCtrl.ReLocation();
        _itemDescCtrl.SetDesc(name, point, stat);
    }

    public void CloseItemDesc()
    {
        _itemDesc.SetActive(false);
    }

    bool CheckSlotType(ItemIconCtrl a, ItemIconCtrl b)
    {
        if (b.tag == "EquipSlot")
        {
            if (a._item._itemType != b._slotType)
            {
                return false;
            }
        }
        return true;
    }

    void ShutDown()
    {
        if (_target == null || _targetInventory == null) return;
        else
        {
            _target.enabled = true;
            _sprite.enabled = false;
        }
    }

    void OnDisable()
    {
        ShutDown();
    }
}
