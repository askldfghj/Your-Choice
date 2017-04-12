using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CardCtrl : MonoBehaviour
{
    public CardInfo _card;
    public StageManager _gm;
    public TweenPosition _cardTween;
    public TweenAlpha _cardTweenAlpha;

    GameObject _currentEvent;

    ResultAndDesc _resultsAndDescs;

    bool _cardEnd;

    string[] _buttonCommands;
    void Awake()
    {
        _buttonCommands = new string[3];
        _resultsAndDescs = new ResultAndDesc();
    }

    void OnEnable()
    {
        _cardEnd = false;
        transform.rotation = Quaternion.identity;
        _card._flipButton.SetActive(true);
        CardOn();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FlipPress()
    {
        StartCoroutine("FlipCard1");
        ButtonTurnOn();
        _card._flipButton.SetActive(false);
    }

    void ResultDesc(string text)
    {
        _card._frontDesc.text = text;
    }

    void ReFlip()
    {
        ButtonTurnOff();
        StartCoroutine("FlipCard2");
    }

    public void CardGenerate()
    {
        //카드 종류 얻기
        //ex
        _currentEvent = DataPool._current._eventList[1].gameObject;
        _card._frontDesc.text = DataPool._current._ScriptionDic["EncounterMessage"]
                                    [Random.Range(0, DataPool._current._ScriptionDic["EncounterMessage"].Count)];

        //종류에 따른 계산 함수 호출
        _currentEvent.SendMessage("EventCaculate");
        _currentEvent.SendMessage("GetCommands", _buttonCommands);
    }

    public void CardSetting(ResultAndDesc rd)
    {

        //종류에 따른 OnHover 이벤트에 넣을 description 작성 및 배열 or 리스트로 저장
        //샘플, 어택의 경우

        _resultsAndDescs = rd;
    }

    void ButtonsInActive()
    {
        for (int i = 0; i < _card._buttons.Length; i++)
        {
            _card._buttons[i].SetActive(false);
        }
    }

    void ButtonsActive()
    {
        for (int i = 0; i < _card._buttons.Length; i++)
        {
            _card._buttons[i].SetActive(true);
        }
    }

    public void CardEnd()
    {
        _cardEnd = true;
        _card._flipButton.SetActive(false);
        //결과 계산 함수 필요
        _gm.ShowResult("획득 경험치 : 3\n획득 골드 : 10\n획득 아이템 : 없음");
        StartCoroutine("CardOffEffect");
    }

    IEnumerator CardOffEffect()
    {
        yield return new WaitForSeconds(3f);
        CardOff();
    }

    void CardOn()
    {
        _cardTween.callWhenFinished = "";
        _cardTween.from.y = -100;
        _cardTween.to.y = 39;
        _cardTweenAlpha.from = 0;
        _cardTweenAlpha.to = 1;
        _cardTween.Reset();
        _cardTween.Play(true);
        _cardTweenAlpha.Reset();
        _cardTweenAlpha.Play(true);
    }

    void CardOff()
    {
        _cardTween.callWhenFinished = "ResumeStage";
        _cardTween.from.y = 39;
        _cardTween.to.y = -100;
        _cardTweenAlpha.from = 1;
        _cardTweenAlpha.to = 0;
        _cardTween.Reset();
        _cardTween.Play(true);
        _cardTweenAlpha.Reset();
        _cardTweenAlpha.Play(true);
        
    }

    void ResumeStage()
    {
        gameObject.SetActive(false);
        _gm.SetWalk();
        _gm.StartStage();
    }

    public void SetDescription1()
    {
        _card._backEffectDesc.text = _resultsAndDescs.desc[0];
    }

    public void SetDescription2()
    {
        _card._backEffectDesc.text = _resultsAndDescs.desc[1];
    }

    public void SetDescription3()
    {
        _card._backEffectDesc.text = _resultsAndDescs.desc[2];
    }

    void ClickButton1()
    {
        //해당카드 종류 스크립트에 던짐
        _currentEvent.SendMessage(_buttonCommands[0], _resultsAndDescs.result[0]);
    }

    void ClickButton2()
    {
        
    }

    void ClickButton3()
    {
        
    }

    void ButtonTurnOn()
    {
        for (int i = 0; i < _card._buttonUI.Length; i++)
        {
            _card._buttonUI[i].enabled = true;
        }
    }

    void ButtonTurnOff()
    {
        for (int i = 0; i < _card._buttonUI.Length; i++)
        {
            _card._buttonUI[i].enabled = false;
        }
    }

    IEnumerator FlipCard1()
    {
        while (true)
        {
            transform.Rotate(Vector3.up * 218 * Time.deltaTime);
            if (transform.rotation.eulerAngles.y >= 90)
            {
                break;
            }
            yield return null;
        }
        _card._cardBack.SetActive(true);
        _card._cardFront.SetActive(false);
        while (transform.rotation.eulerAngles.y <= 180)
        {
            transform.Rotate(Vector3.up * 218 * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator FlipCard2()
    {
        while (true)
        {
            transform.Rotate(Vector3.up * 218 * Time.deltaTime);
            if (transform.rotation.eulerAngles.y >= 270)
            {
                break;
            }
            yield return null;
        }
        _card._cardBack.SetActive(false);
        _card._cardFront.SetActive(true);
        while (transform.rotation.eulerAngles.y <= 350)
        {
            transform.Rotate(Vector3.up * 218 * Time.deltaTime);
            yield return null;
        }
        transform.rotation = Quaternion.identity;
        if (!_cardEnd) _card._flipButton.SetActive(true);
    }
}

[System.Serializable]
public class CardInfo
{
    public GameObject _cardFront;
    public GameObject _cardBack;
    public GameObject _flipButton;
    public GameObject[] _buttons;
    public UIButtonMessage[] _buttonUI;
    public UILabel _frontDesc;
    public UILabel _backEffectDesc;
}

public class DescriptionInfo
{
    public string _frequency;
    public string _success;
    public string _fail;
    public DescriptionInfo(string fre, string suc, string fail)
    {
        _frequency = fre;
        _success = suc;
        _fail = fail;
    }
}

public class ResultAndDesc
{
    public CaculateResult[] result;
    public string[] desc;

    public ResultAndDesc()
    {
        result = new CaculateResult[3];
        desc = new string[3];
    }

    public void SetObj(CaculateResult[] r, string[] d)
    {
        result = r;
        desc = d;
    }
}

