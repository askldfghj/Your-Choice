using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour
{
    public UIManager _StageUI;
    public GameObject _card;
    public BGScroll _backGround;
    public NarrationCtrl _narration;

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
        _backGround.StartScroll();
        //나레이션 생성 ex) text = textGenerate(int 인덱스, 정보 등등...);
        //StartNarration(DataPool._current._DungeonStartDic[Random.Range(0, DataPool._current._DungeonStartDic.Count)]);
        StartNarration(DataPool._current._ScriptionDic["DungeonStart"]
                                            [Random.Range(0, DataPool._current._ScriptionDic["DungeonStart"].Count)]);
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
        _card.SetActive(true);
        _cardScript.CardGenerate();
    }
}
