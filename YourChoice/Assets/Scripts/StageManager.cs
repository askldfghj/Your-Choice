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

    // Use this for initialization
    void Awake()
    {
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
        StartNarration();
    }

    void StartNarration()
    {
        //나레이션 생성 ex) text = textGenerate(int 인덱스, 정보 등등...);
        string text = "당신의 첫 모험이다. 사실 이 말에는 큰 어폐가 있다.";
        _narration.gameObject.SetActive(true);
        _narration.NarrationOn(text);
    }

    public void StartStage()
    {
        StartCoroutine("EventEncounter");
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
        _backGround.StopScroll();
        _card.SetActive(true);
        _cardScript.CardGenerate();
    }
}
