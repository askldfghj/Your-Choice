using UnityEngine;
using System;
using System.Collections;

public class ObjectInfo : ICloneable
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

    public object Clone()
    {
        ObjectInfo obj = new ObjectInfo(_name, _health, _str, _dex, _int, _wep, _arm);
        return obj;
    }
}
