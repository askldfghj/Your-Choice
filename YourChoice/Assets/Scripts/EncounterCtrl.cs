using UnityEngine;
using System.Collections;

public class EncounterCtrl : MonoBehaviour, IEventScript
{
    public GameObject _card;
    public PlayerObj _player;
    public StageManager _gm;

    ObjectInfo _enemy;
    ResultAndDesc _resultAndDesc;
    MonsterResult[] _result;
    string[] _commands;
    string[] _commandsText;

    int _eventCount;

    void Awake()
    {
        _result = new MonsterResult[3];
        _commands = new string[] { "Attack", "Run", "Surprise" };
        _commandsText = new string[] { "A. 공격" , "B. 도망" , "C. 기습"};
    }

    void Attack()
    {
        if (Random.Range(0.1f, 100f) <= _result[0]._frequency)
        {
            //성공
            string text = "그대는 " + _enemy._name + "에게 " + _result[0]._success + "의 데미지를 입혔다.";
            _enemy._health -= _result[0]._success;
            

            string narration;
            if (_enemy._health < 0)
            {
                //적 처치

                text += "\n" + "적이 쓰러졌다.";
                //처치보상 함수 필요

                narration = DataPool._current._ScriptionDic["MonsterDown"]
                                            [Random.Range(0, DataPool._current._ScriptionDic["MonsterDown"].Count)];

                _card.SendMessage("CardEnd");
                

                _gm.SetEnd();
            }
            else
            {
                narration = DataPool._current._ScriptionDic["PlayerAttack"]
                                            [Random.Range(0, DataPool._current._ScriptionDic["PlayerAttack"].Count)];

                //적 생존
            }
            _card.SendMessage("SetFrontDesc", text);
            _gm.StartNarration(narration);
        }
        else
        {
            //실패
            if (Random.Range(0.1f, 100f) <= 70)
            {
                //적의 공격 성공
                _card.SendMessage("SetFrontDesc", _enemy._name + "(는/이) 그대에게 3의 데미지를 입혔다.");
                _gm.StartNarration(DataPool._current._ScriptionDic["MonsterAttack"]
                                            [Random.Range(0, DataPool._current._ScriptionDic["MonsterAttack"].Count)]);
                _player.Damaged(3);
                _gm.SetPlayerHPOnUI();
            }
            else
            {
                //적의 공격 실패
                _card.SendMessage("SetFrontDesc", "서로 회피하였다.");
                _gm.StartNarration(DataPool._current._ScriptionDic["Miss"]
                                            [Random.Range(0, DataPool._current._ScriptionDic["Miss"].Count)]);

            }
        }
        _card.SendMessage("ReFlip");
        _eventCount++;
    }
    void Run()
    {
        if (Random.Range(0.1f, 100f) <= _result[1]._frequency)
        {
            //성공
            _card.SendMessage("SetFrontDesc", "도망에 성공했다.");
            _gm.StartNarration(DataPool._current._ScriptionDic["RunSuccess"]
                                        [Random.Range(0, DataPool._current._ScriptionDic["RunSuccess"].Count)]);
            _card.SendMessage("CardEnd");
            _gm.SetEnd();
        }
        else
        {
            //실패
            _card.SendMessage("SetFrontDesc", _enemy._name + "(는/이) 그대에게 3의 데미지를 입혔다.");
            _gm.StartNarration(DataPool._current._ScriptionDic["RunFail"]
                                        [Random.Range(0, DataPool._current._ScriptionDic["RunFail"].Count)]);
            _player.Damaged(3);
            _gm.SetPlayerHPOnUI();
        }
        _card.SendMessage("ReFlip");
        _eventCount++;
    }
    void Surprise()
    {
        if (Random.Range(0.1f, 100f) <= _result[2]._frequency)
        {
            //성공
            string text = "그대는 " + _enemy._name + "에게 " + _result[2]._success + "의 데미지를 입혔다.";
            _enemy._health -= _result[2]._success ;

            string narration;
            
            if (_enemy._health < 0)
            {
                //적 처치

                text += "\n" + "적이 쓰러졌다.";
                //처치보상 함수 필요

                narration = DataPool._current._ScriptionDic["MonsterDown"]
                                            [Random.Range(0, DataPool._current._ScriptionDic["MonsterDown"].Count)];

                _card.SendMessage("CardEnd");


                _gm.SetEnd();
            }
            else
            {
                narration = DataPool._current._ScriptionDic["PlayerSurprise"]
                                            [Random.Range(0, DataPool._current._ScriptionDic["PlayerSurprise"].Count)];
                //적 생존
            }
            _eventCount++;
            _card.SendMessage("SetFrontDesc", text);
            _gm.StartNarration(narration);

        }
        else
        {
            //실패
            if (Random.Range(0.1f, 100f) <= 70)
            {
                //적의 공격 성공
                _card.SendMessage("SetFrontDesc", _enemy._name + "(는/이) 그대에게 6의 데미지를 입혔다.");
                _gm.StartNarration(DataPool._current._ScriptionDic["MonsterSurprise"]
                                            [Random.Range(0, DataPool._current._ScriptionDic["MonsterSurprise"].Count)]);
                _player.Damaged(3*2);
                _gm.SetPlayerHPOnUI();
            }
            else
            {
                //적의 공격 실패
                _card.SendMessage("SetFrontDesc", "서로 회피하였다.");
                _gm.StartNarration(DataPool._current._ScriptionDic["Miss"]
                                            [Random.Range(0, DataPool._current._ScriptionDic["Miss"].Count)]);

            }
        }
        _card.SendMessage("ReFlip");
    }

    public void EventCaculate()
    {
        //적 생성
        //_enemy = (ObjectInfo) DataPool._current._objectDic[0].Clone();
        //ObjectInfo temp = (ObjectInfo)DataPool._current._eventObjDic["Monster"][0];
        //_enemy = (ObjectInfo)temp.Clone();
        _enemy = (ObjectInfo)DataPool._current._eventObjDic["Monster"][0].Clone();
        _eventCount = 0;

        _resultAndDesc = CaculateScript.MonsterEncounter(_enemy);
        _result = (MonsterResult[])_resultAndDesc.result;
        _card.SendMessage("CardSetting", _resultAndDesc.desc);
        _card.SendMessage("SetFrontDesc", DataPool._current._ScriptionDic["EncounterMessage"]
                                    [Random.Range(0, DataPool._current._ScriptionDic["EncounterMessage"].Count)]);
    }

    public void GetCommands(ref string[] _gmCommands)
    {
        for (int i = 0; i < _commands.Length; i++)
        {
            _gmCommands[i] = _commands[i];
        }
    }

    public void GetCommandsText(ref string[] _gmCommandsText)
    {
        for (int i = 0; i < _commandsText.Length; i++)
        {
            _gmCommandsText[i] = _commandsText[i];
        }
    }

    public void CommandArrange()
    {
        if (_eventCount > 0)
        {
            _card.SendMessage("Button3InAcitve");
        }
    }
}
