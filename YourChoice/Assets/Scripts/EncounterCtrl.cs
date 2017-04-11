using UnityEngine;
using System.Collections;

public class EncounterCtrl : MonoBehaviour, IEventScript
{
    public GameObject _card;
    public PlayerObj _player;
    public StageManager _gm;
    string[] _commands;

    void Awake()
    {
        _commands = new string[] { "Attack", "Run", "Surprise" };
    }

    void Attack(CaculateResult result)
    {
        if (Random.Range(0f, 100f) < result._frequency)
        {
            //성공
            string text = "그대는 " + DataPool._current._objectDic[0]._name + "에게 " +
                          result._success + "의 데미지를 입혔다.";
            _card.SendMessage("ResultDesc", text);
            _gm.StartNarration(DataPool._current._ScriptionDic["PlayerAttack"]
                                            [Random.Range(0, DataPool._current._ScriptionDic["PlayerAttack"].Count)]);
        }
        else
        {
            //실패
            if (Random.Range(0f, 100f) < 70)
            {
                //적의 공격 성공
                _card.SendMessage("ResultDesc", DataPool._current._objectDic[0]._name + "(는/이) 그대에게 3의 데미지를 입혔다.");
                _gm.StartNarration(DataPool._current._ScriptionDic["MonsterAttack"]
                                            [Random.Range(0, DataPool._current._ScriptionDic["MonsterAttack"].Count)]);
                _player.Damaged(3);
                _gm.SetPlayerHPOnUI();
            }
            else
            {
                //적의 공격 실패
                _card.SendMessage("ResultDesc", "서로 회피하였다.");
                _gm.StartNarration(DataPool._current._ScriptionDic["Miss"]
                                            [Random.Range(0, DataPool._current._ScriptionDic["Miss"].Count)]);
            }
        }
        _card.SendMessage("ReFlip");
    }
    void Run(CaculateResult result)
    {
        if (Random.Range(0f, 100f) <= result._frequency)
        {
            //성공

        }
        else
        {
            //실패

        }
    }
    void Surprise(CaculateResult result)
    {
        if (Random.Range(0f, 100f) <= result._frequency)
        {
            //성공

        }
        else
        {
            //실패

        }
    }

    public void GetCommands(ref string[] _gmCommands)
    {
        for (int i = 0; i < _commands.Length; i++)
        {
            _gmCommands[i] = _commands[i];
        }
    }
}
