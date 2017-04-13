using UnityEngine;
using System.Collections;

public class CaculateScript
{
    public static ResultAndDesc MonsterEncounter(ObjectInfo enemy)
    {
        ResultAndDesc rd = new ResultAndDesc();

        rd.result[0] = PlayerAttack(enemy);
        rd.result[1] = PlayerEscape(enemy);

        //기습은 첫 전투시만 가능
        rd.result[2] = PlayerSurprise(enemy);


        rd.desc[0] = "성공확률 : " + rd.result[0]._frequency + " %" + "\n" +
                                     "성공시 : " + rd.result[0]._success + " 데미지의 공격" + "\n" +
                                     "실패시 : 패널티 없음";
        rd.desc[1] = "성공확률 : " + rd.result[1]._frequency + " %" + "\n" +
                                     "성공시 : " + "도망" + "\n" +
                                     "실패시 : 피격률 100%";
        rd.desc[2] = "성공확률 : " + rd.result[2]._frequency + " %" + "\n" +
                                     "성공시 : " + rd.result[2]._success + " 데미지의 공격" + "\n" +
                                     "실패시 : 다음 피격 2배";
        return rd;
    }

    static CaculateResult PlayerAttack(ObjectInfo enemy)
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
        return new CaculateResult(frequency, dam, faildam);
    }

    static CaculateResult PlayerEscape(ObjectInfo enemy)
    {
        //성공확률
        int frequency = 100 - Mathf.Abs(((PlayerObj._current._playerInfo._dex - enemy._dex * 2) * 10));
        if (frequency < 0) frequency = 0;
        //성공시
        int dam = 0;
        //실패시
        int faildam = ((enemy._str + enemy._wep) - PlayerObj._current._playerInfo._arm) * 2;
        if (faildam < 0) faildam = 0;
        return new CaculateResult(frequency, dam, faildam);
    }

    static CaculateResult PlayerSurprise(ObjectInfo enemy)
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
