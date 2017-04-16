using UnityEngine;
using System.Collections;

public class TreasureCtrl : MonoBehaviour, IEventScript
{

    public GameObject _card;
    public PlayerObj _player;
    public StageManager _gm;

    TreasureResult[] _result;
    ResultAndDesc _resultAndDesc;
    string[] _commands;
    string[] _commandsText;

    bool mimic;

    void Awake()
    {
        _result = new TreasureResult[3];
        _commands = new string[] { "Open", "Skip", "Broken" };
        _commandsText = new string[] { "A. 열기", "B. 지나가기", "C. 부수기" };
    }

    void Open()
    {
        if (!mimic)
        {
            string narration = "";
            string text = _result[0]._treasure._items[0]._name + " 획득\n" + _result[0]._treasure.gold + " 골드 획득";
            _card.SendMessage("SetFrontDesc", text);
            _gm.StartNarration(narration);
            _gm.SetEnd();
            _card.SendMessage("CardEnd");
            _card.SendMessage("ReFlip");
        }
        else
        {
            string narration = "";
            _gm.StartNarration(narration);
            string text = "응 미믹";
            _card.SendMessage("ChangeEvent", DataPool._current._eventList[1].gameObject);
            _card.SendMessage("SetFrontDesc", text);
            _card.SendMessage("ReFlip");
        }
    }

    void Skip()
    {

    }

    void Broken()
    {

    }


    public void EventCaculate()
    {
        mimic = true;
        _card.SendMessage("SetFrontDesc", DataPool._current._ScriptionDic["FindBox"]
                                    [Random.Range(0, DataPool._current._ScriptionDic["FindBox"].Count)]);
        //_card.SendMessage("CardSetting", CaculateScript.MonsterEncounter(_enemy));
        _resultAndDesc = CaculateScript.TreasureEncounter(mimic);
        _result = (TreasureResult[])_resultAndDesc.result;
        //results[0] = new CaculateResult(50, 0, 0);
        //results[1] = new CaculateResult(60, 0, 0);
        //results[2] = new CaculateResult(70, 0, 0);
        //ResultAndDesc rd = new ResultAndDesc();
        //rd.SetObj(results, desc);
        _card.SendMessage("CardSetting", _resultAndDesc.desc);
        _card.SendMessage("SetFrontDesc", DataPool._current._ScriptionDic["FindBox"]
                                    [Random.Range(0, DataPool._current._ScriptionDic["FindBox"].Count)]);
    }

    public void GetCommands(ref string[] _gmCommands)
    {
        for (int i = 0; i < _commands.Length; i++)
        {
            _gmCommands[i] = _commands[i];
        }
    }

    public void CommandArrange()
    {
        
    }

    public void GetCommandsText(ref string[] _gmCommandsText)
    {
        for (int i = 0; i < _commandsText.Length; i++)
        {
            _gmCommandsText[i] = _commandsText[i];
        }
    }
}
