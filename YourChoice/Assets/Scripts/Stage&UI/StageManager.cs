using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour
{
    public UIManager _StageUI;
    public GameObject _card;
    public BGScroll _backGround;
    public StageLineCtrl _stageLine;
    public NarrationCtrl _narration;
    public InventoryManager _invenManager;
    public UILabel _resultDesc;
    public TweenAlpha _resultAlpha;
    public BoxCollider[] _colliders;
    public UIButtonCtrl _uibtn;

    bool[] _collsenabled;


    WaitForSeconds _encounterSec;
    float _encounterRate;
    float _encRateInit;
    CardCtrl _cardScript;

    enum StageState { Walk = 0, Encounter, End };
    StageState _state;

    // Use this for initialization
    void Awake()
    {
        _state = StageState.Walk;
        Screen.SetResolution(Screen.width, (Screen.width / 16) * 9, true);
        _encounterSec = new WaitForSeconds(3f);
        _encRateInit = 20f;
        _cardScript = _card.GetComponent<CardCtrl>();
        _collsenabled = new bool[_colliders.Length];
    }

    void Start()
    {
        XmlReader._current.FileRead();
        _StageUI.SetPlayerHP();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FileLoadingEnd()
    {
        SetWalk();
        //나레이션 생성 ex) text = textGenerate(int 인덱스, 정보 등등...);
        StartNarration(DataPool._current._ScriptionDic["DungeonStart"]
                                            [Random.Range(0, DataPool._current._ScriptionDic["DungeonStart"].Count)]);

        //인벤토리 초기화및 정리
        _invenManager.ApplyEquipItems();
        StartStage();
    }

    public void PauseColliders()
    {
        _invenManager.InventoryColliderShutDown();
        _uibtn.AllColliderShutDown();
        for (int i = 0; i < _colliders.Length; i++)
        {
            _collsenabled[i] = _colliders[i].enabled;
            _colliders[i].enabled = false;
        }
    }

    public void ResumeColliders()
    {
        _uibtn.AllBtnShutOn();
        _invenManager.InventoryColliderShutOn();
        for (int i = 0; i < _colliders.Length; i++)
        {
            _colliders[i].enabled = _collsenabled[i];
        }
    }

    public void ShowResult(string str)
    {
        _resultDesc.text = str;
        StopCoroutine("ShowResultEffect");
        StartCoroutine("ShowResultEffect");
    }
    
    IEnumerator ShowResultEffect()
    {
        ResultOn();
        yield return new WaitForSeconds(7f);
        ResultOff();
    }

    void ResultOn()
    {
        _resultAlpha.callWhenFinished = "";
        _resultAlpha.from = 0;
        _resultAlpha.to = 1;
        _resultAlpha.Reset();
        _resultAlpha.Play(true);
    }

    void ResultOff()
    {
        _resultAlpha.callWhenFinished = "ResultTurnOff";
        _resultAlpha.from = 1;
        _resultAlpha.to = 0;
        _resultAlpha.Reset();
        _resultAlpha.Play(true);
    }

    void ResultTurnOff()
    {
        _resultDesc.text = "";
    }

    public void StartNarration(string text)
    {
        _narration.gameObject.SetActive(true);
        _narration.NarrationOn(text);
    }

    public void SetPlayerHPOnUI()
    {
        _StageUI.SetPlayerHP();
    }

    public void StartStage()
    {
        if (_state == StageState.Walk)
        {
            StartCoroutine("EventEncounter");
        }
    }

    public void BGScrollStart()
    {
        
    }

    public void SetWalk()
    {
        _state = StageState.Walk;
        _backGround.StartScroll();
        _stageLine.StartRun();
        _uibtn.AllBtnShutOn();
    }

    public void SetEncounter()
    {
        _state = StageState.Encounter;
    }

    public void SetEnd()
    {
        _state = StageState.End;
    }

    IEnumerator EventEncounter()
    {
        yield return _encounterSec;
        _encounterRate = _encRateInit;
        while (true)
        {
            if (Random.Range(0f, 100f) <= _encounterRate)
            {
                break;
            }
            else
            {
                _encounterRate += 10f;
            }
            yield return _encounterSec;
        }
        _state = StageState.Encounter;
        _backGround.StopScroll();
        _stageLine.PauseRun();
        _uibtn.AllBtnShutDown();
        _card.SetActive(true);
        _cardScript.CardGenerate();
    }
}
