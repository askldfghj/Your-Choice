using UnityEngine;
using System.Collections;

public class ItemDescCtrl : MonoBehaviour
{
    public UILabel _name;
    public UILabel _majorpoint;
    public UILabel _majorStat;

    public void SetDesc(string name, string point, string stat)
    {
        _name.text = name;
        _majorpoint.text = point;
        _majorStat.text = stat;
    }
}
