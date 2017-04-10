using UnityEngine;
using System.Collections;

public class ObjectInfo
{
    public string _name
    {
        get;
        set;
    }

    public int _health
    {
        get;
        set;
    }
    public int _str
    {
        get;
        set;
    }
    public int _dex
    {
        get;
        set;
    }
    public int _int
    {
        get;
        set;
    }
    public int _wep
    {
        get;
        set;
    }
    public int _arm
    {
        get;
        set;
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
}
