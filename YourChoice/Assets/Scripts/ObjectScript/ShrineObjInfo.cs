using UnityEngine;
using System.Collections;

public class ShrineObjInfo : EventObject
{
    public string _effect;

    public ShrineObjInfo()
    {
        _effect = "";
    }

    public void SetEffect(string ef)
    {
        _effect = ef;
    }
 }
