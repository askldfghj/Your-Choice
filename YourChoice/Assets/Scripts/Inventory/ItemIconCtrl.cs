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
    bool _isClick = false;

    void Awake()
    {
        _cursor = GameObject.Find("Cursor").GetComponent<CursorCtrl>();
    }

    void OnEnable()
    {
        _isDrag = false;
        _isClick = false;
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

    void OnHover(bool isOver)
    {
        if (_item._spriteName != "")
        {
            string stat = "";
            string point = "";
            if (isOver)
            {
                switch (_item._itemType)
                {
                    case "wep":
                        stat = "공격력";
                        point = _item._wep.ToString();
                        break;
                    case "arm":
                        stat = "방어력";
                        point = _item._arm.ToString();
                        break;
                }
                _cursor.ShowItemDesc(_item._name, point, stat);
            }
            else
            {
                _cursor.CloseItemDesc();
            }
        }
    }

    void OnPress(bool isDown)
    {
        if (isDown && UICamera.currentTouchID > -2)
        {
            if (_sprite.enabled)
            {
                _isDrag = true;
                _isClick = true;
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

    void OnClick()
    {
        if (_isClick)
        {
            _cursor.ItemClick();
            _isClick = false;
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
