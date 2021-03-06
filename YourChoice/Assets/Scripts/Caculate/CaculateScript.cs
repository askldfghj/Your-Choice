﻿using UnityEngine;
using System.Collections;

public class CaculateScript
{
    public static ResultAndDesc MonsterEncounter(ObjectInfo enemy)
    {
        ResultAndDesc rd = new ResultAndDesc();
        MonsterResult[] result = new MonsterResult[3];
        result[0] = PlayerAttack(enemy);
        result[1] = PlayerEscape(enemy);
        result[2] = PlayerSurprise(enemy);

        rd.desc[0] = "성공확률 : " + result[0]._frequency + " %" + "\n" +
                                     "성공시 : " + result[0]._success + " 데미지의 공격" + "\n" +
                                     "실패시 : 패널티 없음";
        rd.desc[1] = "성공확률 : " + result[1]._frequency + " %" + "\n" +
                                     "성공시 : " + "도망" + "\n" +
                                     "실패시 : 피격률 100%";
        rd.desc[2] = "성공확률 : " + result[2]._frequency + " %" + "\n" +
                                     "성공시 : " +result[2]._success + " 데미지의 공격" + "\n" +
                                     "실패시 : 다음 피격 2배";
        rd.SetResult(result);

        return rd;
    }
    static MonsterResult PlayerAttack(ObjectInfo enemy)
    {
        //성공확률
        int frequency = 100 - Mathf.Abs(((PlayerObj._current._playerInfo._dex - enemy._dex) * 5));
        if (frequency < 0) frequency = 0;
        //성공시
        int dam = (PlayerObj._current._playerInfo._str + PlayerObj._current._playerInfo._wep) - enemy._arm;
        if (dam < 0) dam = 0;
        //실패시
        int faildam = ((enemy._str + enemy._wep) - PlayerObj._current._playerInfo._arm);
        if (faildam < 0) faildam = 0;
        return new MonsterResult(frequency, dam, faildam);
    }
    static MonsterResult PlayerEscape(ObjectInfo enemy)
    {
        //성공확률
        int frequency = 100 - Mathf.Abs(((PlayerObj._current._playerInfo._dex - enemy._dex * 2) * 10));
        if (frequency < 0) frequency = 0;
        //성공시
        int dam = 0;
        //실패시
        int faildam = ((enemy._str + enemy._wep) - PlayerObj._current._playerInfo._arm) * 2;
        if (faildam < 0) faildam = 0;
        return new MonsterResult(frequency, dam, faildam);
    }
    static MonsterResult PlayerSurprise(ObjectInfo enemy)
    {
        //성공확률
        int frequency = 100 - Mathf.Abs(((PlayerObj._current._playerInfo._dex - enemy._dex) * 10) * 2);
        if (frequency < 0) frequency = 0;
        //성공시
        int dam = ((PlayerObj._current._playerInfo._str + PlayerObj._current._playerInfo._wep) - enemy._arm) * 2;
        if (dam < 0) dam = 0;
        //실패시
        int faildam = ((enemy._str + enemy._wep) - PlayerObj._current._playerInfo._arm) * 2;
        if (faildam < 0) faildam = 0;
        return new MonsterResult(frequency, dam, faildam);
    }
    public static int MonsterAttack(ObjectInfo enemy)
    {
        return 3;
    }

    public static ResultAndDesc TreasureEncounter(bool mimic)
    {
        ResultAndDesc rd = new ResultAndDesc();
        TreasureResult[] result = new TreasureResult[3];
        result[0] = TreasureOpen(mimic);
        result[1] = TreasureSkip();
        result[2] = TreasureBroken(mimic);
        rd.desc[0] = "1번";
        rd.desc[1] = "2번";
        rd.desc[2] = "3번";
        rd.SetResult(result);
        return rd;
    }
    static TreasureResult TreasureOpen(bool mimic)
    {
        if (!mimic)
        {
            TreasureResult result = new TreasureResult();
            result._treasure = new TreasureObjInfo();
            result._treasure._items = new ItemObjInfo[1];
            result._treasure._items[0] = new ItemObjInfo();
            result._treasure._items[0]._name = "보물";
            result._treasure.gold = 10;
            return result;
        }
        else
        {
            return null;
        }
    }
    static TreasureResult TreasureSkip()
    {
        return null;
    }
    static TreasureResult TreasureBroken(bool mimic)
    {
        return null;
    }

    public static TrapResult PlayerTraped()
    {
        TrapResult result = new TrapResult();
        result.trapDam = Random.Range(3, 10);
        return result;
    }

    public static ResultAndDesc ShrineEncounter()
    {
        ResultAndDesc rd = new ResultAndDesc();
        ShrineResult[] result = new ShrineResult[3];
        //타입 설정하는 함수 필요
        result[0] = GetShrineEffect();
        result[1] = null;
        result[2] = null;
        rd.desc[0] = "1번";
        rd.desc[1] = "2번";
        rd.desc[2] = "";
        rd.SetResult(result);
        return rd;
    }
    static ShrineResult GetShrineEffect()
    {
        ShrineResult result = new ShrineResult();
        //타입 인자로 받아야함
        result.EffectCaculate();
        return result;
    }
}

public class CaculateResult
{
}

public class MonsterResult : CaculateResult
{
    public int _frequency;
    public int _success;
    public int _fail;

    public MonsterResult(int fre, int suc, int fail)
    {
        _frequency = fre;
        _success = suc;
        _fail = fail;
    }
}
public class TreasureResult : CaculateResult
{
    public TreasureObjInfo _treasure;

    public TreasureResult()
    {
        _treasure = null;
    }
}
public class ShrineResult : CaculateResult
{
    public ShrineObjInfo _shrine;

    public ShrineResult()
    {
        _shrine = new ShrineObjInfo();
    }

    public void EffectCaculate()
    {
        //인자 힘의 신단 속도의 신단 등, 신단의 타입
        //해야하는 일
        //타입에 따른 저주 or 축복
        _shrine.SetEffect("sample");
    }
}

public class TrapResult
{
    public int trapDam;
}

public class ResultAndDesc
{
    public CaculateResult[] result;
    public string[] desc;

    public ResultAndDesc()
    {
        desc = new string[3];
    }

    public void SetResult(CaculateResult[] r)
    {
        result = r;
    }
}
