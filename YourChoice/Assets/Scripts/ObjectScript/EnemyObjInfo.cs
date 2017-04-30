using UnityEngine;
using System.Collections;

public class EnemyObjInfo : ObjectInfo
{
    public int _exp;
    public int _gold;
    public ItemObjInfo[] _dropItems;

    public EnemyObjInfo(string name, int health, int str, int dex, int intel, int wep, int arm, int exp, int gold)
    {
        _name = name;
        _health = health;
        _str = str;
        _dex = dex;
        _int = intel;
        _wep = wep;
        _arm = arm;
        _exp = exp;
        _gold = gold;
    }

    public void SetDropItem()
    {
        int num = Random.Range(0, 3);
        _dropItems = new ItemObjInfo[num];
        //아이템 테이블 필요
    }

    public override EventObject Clone()
    {
        EnemyObjInfo obj = new EnemyObjInfo(_name, _health, _str, _dex, _int, _wep, _arm, _exp, _gold);
        return obj;
    }
}
