using UnityEngine;
using System.Collections;

public class ShrineObjInfo : ObjectInfo
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
