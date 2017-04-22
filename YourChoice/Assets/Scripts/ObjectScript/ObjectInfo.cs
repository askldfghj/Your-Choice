using UnityEngine;
using System.Collections;

public class ObjectInfo : EventObject
{
    public string _name;
    public int _health;
    public int _str;
    public int _dex;
    public int _int;
    public int _wep;
    public int _arm;

    public ObjectInfo()
    {
        _name = "";
        _health = 0;
        _str = 0;
        _dex = 0;
        _int = 0;
        _wep = 0;
        _arm = 0;
    }

    public ObjectInfo(string name, int health, int str, int dex, int intel, int wep, int arm)
    {
        _name = name;
        _health = health;
        _str = str;
        _dex = dex;
        _int = intel;
        _wep = wep;
        _arm = arm;
    }

    public override EventObject Clone()
    {
        ObjectInfo obj = new ObjectInfo(_name, _health, _str, _dex, _int, _wep, _arm);
        return obj;
    }
}
