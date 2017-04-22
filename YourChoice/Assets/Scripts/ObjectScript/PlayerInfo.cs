using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInfo : ObjectInfo
{
    public Dictionary<string, ItemObjInfo> _equipItem;

    public PlayerInfo()
    {
        _equipItem = new Dictionary<string, ItemObjInfo>();
        _equipItem.Add("wep", new ItemObjInfo());
        _equipItem.Add("arm", new ItemObjInfo());
        _equipItem.Add("acc", new ItemObjInfo());
    }

    public PlayerInfo (string name, int health, int str, int dex, int intel, int wep, int arm)
    {
        _name = name;
        _health = health;
        _str = str;
        _dex = dex;
        _int = intel;
        _wep = wep;
        _arm = arm;
        _equipItem = new Dictionary<string, ItemObjInfo>();
        _equipItem.Add("wep", new ItemObjInfo());
        _equipItem.Add("arm", new ItemObjInfo());
        _equipItem.Add("acc", new ItemObjInfo());
    }
}
