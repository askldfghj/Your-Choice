using UnityEngine;
using System.Collections;

public class ItemIconCtrl : MonoBehaviour
{
    public string _InventoryName;
    public string _slotType;
    public UISprite _sprite;
    public ItemObjInfo _item;
    CursorCtrl _cursor;

    bool _isDrag = false;

    void Awake()
    {
        _cursor = GameObject.Find("Cursor").GetComponent<CursorCtrl>();

    }

    void Start()
    {
        if (_item._spriteName != "")
        {
            _sprite.spriteName = _item._spriteName;
        }
        else
        {
            _sprite.enabled = false;
        }
    }

    void OnPress(bool isDown)
    {
        if (isDown && UICamera.currentTouchID > -2)
        {
            if (_sprite.enabled)
            {
                _isDrag = true;
                _cursor.PressCursor(this, transform.position, _sprite.spriteName);
                _sprite.enabled = false;
            }
        }
        else
        {
            if (_isDrag)
            {
                _cursor.Drop();
            }
            _isDrag = false;
        }
    }

    void OnDrag(Vector2 delta)
    {
        _cursor.Drag();
    }

    public void GetItem(ItemObjInfo newItem)
    {
        _item = newItem;
    }
}
