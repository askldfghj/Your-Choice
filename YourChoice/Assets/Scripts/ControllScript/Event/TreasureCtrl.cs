using UnityEngine;
using System.Collections;

public class TreasureCtrl : MonoBehaviour, IEventScript
{

    public GameObject _card;
    public PlayerObj _player;
    public StageManager _gm;

    TreasureResult[] _result;
    ResultAndDesc _resultAndDesc;
    CardCtrl _cardScript;
    string[] _commands;
    string[] _commandsText;

    bool mimic;

    void Awake()
    {
        _cardScript = _card.GetComponent<CardCtrl>();
        _result = new TreasureResult[3];
        _commands = new string[] { "Open", "Skip", "Broken" };
        _commandsText = new string[] { "A. 열기", "B. 지나가기", "C. 부수기" };
    }

    void Open()
    {
        string text = "";
        string narration = "";
        if (!mimic)
        {
            text = _result[0]._treasure._items[0]._name + " 획득\n" + _result[0]._treasure.gold + " 골드 획득";
            narration = DataPool._current._ScriptionDic["FindTresure"]
                                            [Random.Range(0, DataPool._current._ScriptionDic["FindTresure"].Count)];
            _gm.StartNarration(narration);
            _gm.SetEnd();
            _cardScript.CardEnd();
        }
        else
        {
            narration = DataPool._current._ScriptionDic["Mimic"]
                                            [Random.Range(0, DataPool._current._ScriptionDic["Mimic"].Count)];
            _gm.StartNarration(narration);
            text = "응 미믹";
            ObjectInfo enemy = (ObjectInfo)DataPool._current._eventObjDic["Mimic"][0].Clone();
            _cardScript.ChangeToMonster(enemy);
        }
        _cardScript.SetFrontDesc(text);
        _cardScript.ReFlip();
    }

    void Skip()
    {
        string narration = "";
        string text = "무시하고 지나쳤다.";
        narration = DataPool._current._ScriptionDic["BoxSkip"]
                                            [Random.Range(0, DataPool._current._ScriptionDic["BoxSkip"].Count)];
        _gm.StartNarration(narration);
        _gm.SetEnd();
        _cardScript.SetFrontDesc(text);
        _cardScript.CardEnd();
        _cardScript.ReFlip();
    }

    void Broken()
    {
        string text = "";
        string narration = "";
        if (!mimic)
        {
            text = "상자는 산산조각이 났다.";
            narration = DataPool._current._ScriptionDic["Broken"]
                                            [Random.Range(0, DataPool._current._ScriptionDic["Broken"].Count)];
            _gm.StartNarration(narration);
            _gm.SetEnd();
            _cardScript.CardEnd();
        }
        else
        {
            narration = DataPool._current._ScriptionDic["BrokenMimic"]
                                            [Random.Range(0, DataPool._current._ScriptionDic["BrokenMimic"].Count)];
            _gm.StartNarration(narration);
            text = "미믹이 맞았다!";
            ObjectInfo enemy = (ObjectInfo)DataPool._current._eventObjDic["Mimic"][0].Clone();
            _cardScript.ChangeToMonster(enemy);
        }
        _cardScript.SetFrontDesc(text);
        _cardScript.ReFlip();
    }


    public void EventCaculate()
    {
        mimic = true;
        _cardScript.SetFrontDesc(DataPool._current._ScriptionDic["FindBox"]
                                    [Random.Range(0, DataPool._current._ScriptionDic["FindBox"].Count)]);
        _resultAndDesc = CaculateScript.TreasureEncounter(mimic);
        _result = (TreasureResult[])_resultAndDesc.result;
        _cardScript.CardSetting(_resultAndDesc.desc);
        _cardScript.SetFrontDesc(DataPool._current._ScriptionDic["FindBox"]
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
