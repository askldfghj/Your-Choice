using UnityEngine;
using System.Collections;

public class TreasureCtrl : MonoBehaviour, IEventScript
{

    public GameObject _card;
    public PlayerObj _player;
    public StageManager _gm;

    string[] _commands;
    string[] _commandsText;

    void Awake()
    {
        _commands = new string[] { "Open", "Skip", "Broken" };
        _commandsText = new string[] { "A. 열기", "B. 지나가기", "C. 부수기" };
    }

    void Open()
    {

    }

    void Skip()
    {

    }

    void Broken()
    {

    }


    public void EventCaculate()
    {

        _card.SendMessage("SetFrontDesc", DataPool._current._ScriptionDic["FindBox"]
                                    [Random.Range(0, DataPool._current._ScriptionDic["FindBox"].Count)]);
        //_card.SendMessage("CardSetting", CaculateScript.MonsterEncounter(_enemy));
        CaculateResult[] results = new CaculateResult[3];
        string[] desc = new string[3];
        results[0] = new CaculateResult(50, 0, 0);
        results[1] = new CaculateResult(60, 0, 0);
        results[2] = new CaculateResult(70, 0, 0);
        ResultAndDesc rd = new ResultAndDesc();
        rd.SetObj(results, desc);
        _card.SendMessage("CardSetting", desc);
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
