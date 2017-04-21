using UnityEngine;
using System.Collections;

public class ItemIconCtrl : MonoBehaviour
{
    public UISprite _sprite;
    CursorCtrl _cursor;

    bool _isDrag = false;

    void Awake()
    {
        _cursor = GameObject.Find("Cursor").GetComponent<CursorCtrl>();
    }

    void SetItem(string sprName)
    {

    }

    void OnPress(bool isDown)
    {
        if (isDown && UICamera.currentTouchID > -2)
        {
            if (_sprite.enabled)
            {
                _isDrag = true;
                _cursor.PressCursor(_sprite, transform.position, _sprite.spriteName);
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
}
