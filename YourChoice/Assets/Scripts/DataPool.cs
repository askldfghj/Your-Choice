using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataPool : MonoBehaviour {

    public static DataPool _current;
    public GameObject _eventSet;
    public Transform[] _eventList;
    public Dictionary<int, ObjectInfo> _objectDic;
    public Dictionary<int, string> _DungeonStartDic;



    public Dictionary<string, List<string>> _ScriptionDic;
    List<string> _DungeonStartScript;
    List<string> _EncounterScript;
    List<string> _PlayerAttackScript;
    List<string> _MonsterAttackScript;
    List<string> _MissScript;

    void Awake()
    {
        _current = this;
        _objectDic = new Dictionary<int, ObjectInfo>();
        _DungeonStartDic = new Dictionary<int, string>();

        _ScriptionDic = new Dictionary<string, List<string>>();
        _DungeonStartScript = new List<string>();
        _EncounterScript = new List<string>();
        _PlayerAttackScript = new List<string>();
        _MonsterAttackScript = new List<string>();
        _MissScript = new List<string>();

        _ScriptionDic.Add("DungeonStart", _DungeonStartScript);
        _ScriptionDic.Add("EncounterMessage", _EncounterScript);
        _ScriptionDic.Add("PlayerAttack", _PlayerAttackScript);
        _ScriptionDic.Add("MonsterAttack", _MonsterAttackScript);
        _ScriptionDic.Add("Miss", _MissScript);

        _eventList = _eventSet.GetComponentsInChildren<Transform>();
    }
}
