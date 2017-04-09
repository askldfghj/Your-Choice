using UnityEngine;
using System.Collections;

public class CaculateScript
{
    public static CaculateResult MonsterAttack(ObjectInfo enemy)
    {
        //성공확률
        int frequency = 100 - ((PlayerObj._current._playerInfo._dex - enemy._dex) * 5);
        if (frequency < 0) frequency = 0;
        //성공시
        int dam = (PlayerObj._current._playerInfo._str + PlayerObj._current._playerInfo._wep) - enemy._arm;
        if (dam < 0) dam = 0;
        //실패시
        int faildam = ((enemy._str + enemy._wep) - PlayerObj._current._playerInfo._arm);
        if (faildam < 0) faildam = 0;
        return new CaculateResult(frequency, dam, faildam);
    }

    public static CaculateResult MonsterEscape(ObjectInfo enemy)
    {
        //성공확률
        int frequency = 100 - (((PlayerObj._current._playerInfo._dex - enemy._dex * 2) * 10));
        if (frequency < 0) frequency = 0;
        //성공시
        int dam = 0;
        //실패시
        int faildam = ((enemy._str + enemy._wep) - PlayerObj._current._playerInfo._arm) * 2;
        if (faildam < 0) faildam = 0;
        return new CaculateResult(frequency, dam, faildam);
    }

    public static CaculateResult MonsterSurprise(ObjectInfo enemy)
    {
        //성공확률
        int frequency = 100 - ((PlayerObj._current._playerInfo._dex - enemy._dex) * 10) * 2;
        if (frequency < 0) frequency = 0;
        //성공시
        int dam = ((PlayerObj._current._playerInfo._str + PlayerObj._current._playerInfo._wep) - enemy._arm) * 2;
        if (dam < 0) dam = 0;
        //실패시
        int faildam = ((enemy._str + enemy._wep) - PlayerObj._current._playerInfo._arm) * 2;
        if (faildam < 0) faildam = 0;
        return new CaculateResult(frequency, dam, faildam);
    }
}

public class CaculateResult
{
    public int _frequency;
    public int _success;
    public int _fail;

    public CaculateResult(int fre, int suc, int fail)
    {
        _frequency = fre;
        _success = suc;
        _fail = fail;
    }
}
