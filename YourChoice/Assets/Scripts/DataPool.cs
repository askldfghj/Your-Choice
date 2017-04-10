using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataPool : MonoBehaviour {

    public static DataPool _current;
    public Dictionary<int, ObjectInfo> _objectDic;

    void Awake()
    {
        _current = this;
        _objectDic = new Dictionary<int, ObjectInfo>();
    }
}
