using UnityEngine;
using System.Collections;

public class CursorCtrl : MonoBehaviour
{
    public UISprite _sprite;
    public Camera _uiCamera;

    UISprite _target; 

    public void PressCursor(UISprite spr, Vector3 pos, string name)
    {
        _target = spr;
        pos.z = 0f;
        transform.position = pos;
        _sprite.enabled = true;
        _sprite.spriteName = name;

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
        if (col != null && col.tag == "ItemSlot")
        {
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
        _sprite.enabled = false;
    }
}
