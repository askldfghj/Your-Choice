using UnityEngine;
using System.Collections;

public class CursorCtrl : MonoBehaviour
{
    public UISprite _sprite;
    public Camera _uiCamera;
    public GameObject _itemDesc;
    public GameObject _itemUse;
    public InventoryManager _invenManager;

    UISprite _targetSprite;
    ItemIconCtrl _targetInventory;
    ItemDescCtrl _itemDescCtrl;
    ItemUseCtrl _itemUseCtrl;

    bool _isDrag;

    void Awake()
    {
        _itemDescCtrl = _itemDesc.GetComponent<ItemDescCtrl>();
        _itemUseCtrl = _itemUse.GetComponent<ItemUseCtrl>();
    }

    void OnEnable()
    {
        _targetSprite = null;
        _itemDesc.SetActive(false);
        _isDrag = false;
    }

    public void PressCursor(ItemIconCtrl icon, Vector3 pos, string name)
    {
        _targetSprite = icon._sprite;
        _targetInventory = icon;
        pos.z = 0f;
        transform.position = pos;
        _sprite.enabled = true;
        _sprite.spriteName = name;
        _itemDesc.SetActive(false);
    }

    public void Drag()
    {
        _isDrag = true;
        Vector3 pos = Input.mousePosition;
        pos.x = Mathf.Clamp01(pos.x / Screen.width);
        pos.y = Mathf.Clamp01(pos.y / Screen.height);
        transform.position = _uiCamera.ViewportToWorldPoint(pos);
    }

    public void Drop()
    {
        if (_isDrag)
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
                            _targetSprite.enabled = true;
                            _targetSprite.spriteName = spr.spriteName;
                        }
                        else
                        {
                            _targetSprite.enabled = false;
                            spr.enabled = true;
                        }
                        spr.spriteName = _sprite.spriteName;
                    }
                    else
                    {
                        _targetSprite.enabled = true;
                    }
                }
                else
                {
                    _targetSprite.enabled = true;
                }
                _sprite.enabled = false;
            }
            else
            {
                _targetSprite.enabled = true;
                _sprite.enabled = false;
            }
        }
        _isDrag = false;
    }

    public void ItemClick()
    {
        _targetSprite.enabled = true;
        _sprite.enabled = false;
        if (!_isDrag)
        {
            _itemUse.SetActive(true);

            Vector3 pos = Input.mousePosition;
            pos.x = Mathf.Clamp01(pos.x / Screen.width);
            pos.y = Mathf.Clamp01(pos.y / Screen.height);
            _itemUse.transform.position = _uiCamera.ViewportToWorldPoint(pos);

            if (_targetInventory._slotType == "slot")
            {
                _itemUseCtrl.SetEquipBtn(_targetInventory);
            }
            else
            {
                _itemUseCtrl.SetUnEquipBtn(_targetInventory);
            }
            _targetSprite.enabled = true;
            _sprite.enabled = false;
        }
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
            if (a.tag == "EquipSlot")
            {
                return false;
            }

            if (a._item._itemType != b._slotType)
            {
                return false;
            }
        }
        else if (b.tag == "ItemSlot")
        {
            if (!b._sprite.enabled)
            {
                return true;
            }
            if (a.tag == "EquipSlot")
            {
                if (a._item._itemType != b._item._itemType)
                {
                    return false;
                }
            }
        }
        return true;
    }

    void ShutDown()
    {
        if (_targetSprite == null || _targetInventory == null) return;
        else
        {
            _targetSprite.enabled = true;
            _sprite.enabled = false;
        }
    }

    void OnDisable()
    {
        ShutDown();
    }
}
