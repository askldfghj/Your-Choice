using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataPool : MonoBehaviour {

    public static DataPool _current;
    public GameObject _eventSet;
    public Transform[] _eventList;
    public Dictionary<string, List<EventObject>> _eventObjDic;
    //public Dictionary<int, string> _DungeonStartDic;



    public Dictionary<string, List<string>> _ScriptionDic;

    //이벤트 오브젝트 리스트
    List<EventObject> _MonsterList; //몬스터


    //던전환경 관련 스크립트
    List<string> _DungeonStartScript;


    //몬스터 조우 관련 스크립트 list
    List<string> _EncounterScript;
    List<string> _PlayerAttackScript;
    List<string> _MonsterAttackScript;
    List<string> _MissScript;
    List<string> _RunSuccessScript;
    List<string> _RunFailScript;
    List<string> _PlayerSurpriseScript;
    List<string> _MonsterSurpriseScript;
    List<string> _MonsterDownScript;

    //보물상자 관련 스크립트
    List<string> _FindBoxScript;
    List<string> _FindTresureScript;
    List<string> _NotTresureScript;
    List<string> _MimicScript;
    List<string> _BoxSkipScript;
    List<string> _BrokenScript;
    List<string> _BrokenMimic;


    void Awake()
    {
        _current = this;
        _eventObjDic = new Dictionary<string, List<EventObject>>();
        //_DungeonStartDic = new Dictionary<int, string>();

        _ScriptionDic = new Dictionary<string, List<string>>();

        //몬스터 리스트
        _MonsterList = new List<EventObject>();
        _eventObjDic.Add("Monster", _MonsterList);


        //던전환경 관련 스크립트
        _DungeonStartScript = new List<string>();
        _ScriptionDic.Add("DungeonStart", _DungeonStartScript);

        //몬스터 조우 관련 스크립트
        _EncounterScript = new List<string>();
        _PlayerAttackScript = new List<string>();
        _MonsterAttackScript = new List<string>();
        _MissScript = new List<string>();
        _RunSuccessScript = new List<string>();
        _RunFailScript = new List<string>();
        _PlayerSurpriseScript = new List<string>();
        _MonsterSurpriseScript = new List<string>();
        _MonsterDownScript = new List<string>();

        _ScriptionDic.Add("EncounterMessage", _EncounterScript);
        _ScriptionDic.Add("PlayerAttack", _PlayerAttackScript);
        _ScriptionDic.Add("MonsterAttack", _MonsterAttackScript);
        _ScriptionDic.Add("Miss", _MissScript);
        _ScriptionDic.Add("RunSuccess", _RunSuccessScript);
        _ScriptionDic.Add("RunFail", _RunFailScript);
        _ScriptionDic.Add("PlayerSurprise", _PlayerSurpriseScript);
        _ScriptionDic.Add("MonsterSurprise", _MonsterSurpriseScript);
        _ScriptionDic.Add("MonsterDown", _MonsterDownScript);

        //보물상자 관련 스크립트
        _FindBoxScript = new List<string>();
        _FindTresureScript = new List<string>();
        _NotTresureScript = new List<string>();
        _MimicScript = new List<string>();
        _BoxSkipScript = new List<string>();
        _BrokenScript = new List<string>();
        _BrokenMimic = new List<string>();

        _ScriptionDic.Add("FindBox", _FindBoxScript);
        _ScriptionDic.Add("FindTresure", _FindTresureScript);
        _ScriptionDic.Add("NotTresure", _NotTresureScript);
        _ScriptionDic.Add("Mimic", _MimicScript);
        _ScriptionDic.Add("BoxSkip", _BoxSkipScript);
        _ScriptionDic.Add("Broken", _BrokenScript);
        _ScriptionDic.Add("BrokenMimic", _BrokenMimic);
        




        _eventList = _eventSet.GetComponentsInChildren<Transform>();
    }
}
