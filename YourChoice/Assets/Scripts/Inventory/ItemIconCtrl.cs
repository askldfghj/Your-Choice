using UnityEngine;
using System.Collections;

public class ItemIconCtrl : MonoBehaviour
{
    public UISprite _sprite;
    string _spriteName = "Square";

    bool _isDrag = false;
    void SetItem(string sprName)
    {
        _sprite.spriteName = "Square";
    }

    void OnDrag(Vector2 delta)
    {
        if (_isDrag)
        {

        }
        else
        {
            _isDrag = true;
            Debug.Log("call");
            _sprite.enabled = true;
            _sprite.spriteName = _spriteName;
        }
    }
}
