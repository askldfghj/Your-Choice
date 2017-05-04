using UnityEngine;
using System.Collections;

public class ShrineCtrl : MonoBehaviour, IEventScript
{
    public GameObject _card;
    public PlayerObj _player;
    public EventObjCtrl _ObejctCtrl;
    public StageManager _gm;

    CardCtrl _cardScript;
    ShrineObjInfo _ShrineInfo;
    ResultAndDesc _resultAndDesc;
    ShrineResult[] _result;
    string[] _commands;
    string[] _commandsText;
    

    void Awake()
    {
        _cardScript = _card.GetComponent<CardCtrl>();
        _result = new ShrineResult[3];
        _commands = new string[] { "Touch", "Skip", "" };
        _commandsText = new string[] { "A. 만지기", "B. 지나가기", "" };
    }

    void Touch()
    {
        string narration = "";
        string effect = _result[0]._shrine._effect;
        Debug.Log(effect);
        string text = _player._playerInfo._name + "은 " + effect + "의 효과를 얻었다.";
        _player._playerInfo._effects.Add(_result[0]._shrine._effect);
        _ObejctCtrl.CloseObject();
        _gm.StartNarration(narration);
        _gm.SetEnd();
        _cardScript.SetFrontDesc(text);
        _cardScript.CardEnd("");
        _cardScript.ReFlip();
    }

    void Skip()
    {
        string narration = "";
        string text = "무시하고 지나쳤다.";
        _gm.StartNarration(narration);
        _gm.SetEnd();
        _cardScript.SetFrontDesc(text);
        _cardScript.CardEnd("");
        _cardScript.ReFlip();
    }

    public void EventCaculate()
    {
        //오브젝트 그림 생성
        //_ShrineInfo

        _ObejctCtrl.OnObject();

        _resultAndDesc = CaculateScript.ShrineEncounter();
        _result = (ShrineResult[])_resultAndDesc.result;
        

        _cardScript.CardSetting(_resultAndDesc.desc);
        _cardScript.SetFrontDesc("신단을 발견했다.");
        CommandArrange();
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
        _card.SendMessage("Button3InAcitve");
    }
}
