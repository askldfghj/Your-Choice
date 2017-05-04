using UnityEngine;
using System.Collections;
using System;

public class TrapCtrl : MonoBehaviour, IEventScript
{

    public GameObject _card;
    public PlayerObj _player;
    public StageManager _gm;

    CardCtrl _cardScript;
    TrapResult result;

    void Awake()
    {
        _cardScript = _card.GetComponent<CardCtrl>();
    }

    public void EventCaculate()
    {
        result = CaculateScript.PlayerTraped();
        string text = "그대는 " + result.trapDam + "의 데미지를 입었다.";
        _player.Damaged(result.trapDam);
        _gm.SetPlayerHPOnUI();
        _cardScript.SetFrontDesc(text);
        _gm.SetEnd();
        _cardScript.CardEnd("");
    }

    public void GetCommands(ref string[] _gmCommands)
    {
    }

    public void CommandArrange()
    {
    }

    public void GetCommandsText(ref string[] _gmCommandsText)
    {
    }
}
