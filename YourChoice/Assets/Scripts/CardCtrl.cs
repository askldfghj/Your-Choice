using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CardCtrl : MonoBehaviour
{
    public CardInfo _card;

    List<string> _descSet;
    void Awake()
    {
        _descSet = new List<string>();
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
        _card._flipButton.SetActive(false);
    }

    public void CardGenerate()
    {
        //카드 종류 얻기

        //종류에 따른 계산 함수 호출
        //샘플 몬스터
        
        _descSet.Clear();


        //ObjectInfo goblin = new ObjectInfo(7, 3, 1, 0, 2, 0);
        //종류에 따른 OnHover 이벤트에 넣을 description 작성 및 배열 or 리스트로 저장
        //샘플, 어택의 경우
        CaculateResult result = CaculateScript.MonsterAttack(DataPool._current._objectDic[0]);
        string desc = "성공확률 : " + result._frequency + " %" + "\n" +
                                     "성공시 : " + result._success + " 데미지의 공격"  + "\n" + 
                                     "실패시 : 패널티 없음";
        _descSet.Add(desc);

        result = CaculateScript.MonsterEscape(DataPool._current._objectDic[0]);
        desc = "성공확률 : " + result._frequency + " %" + "\n" +
                                     "성공시 : " + "도망" + "\n" +
                                     "실패시 : 패널티 없음";
        _descSet.Add(desc);
        result = CaculateScript.MonsterSurprise(DataPool._current._objectDic[0]);
        desc = "성공확률 : " + result._frequency + " %" + "\n" +
                                     "성공시 : " + result._success + " 데미지의 공격" + "\n" +
                                     "실패시 : 다음 피격 2배";
        _descSet.Add(desc);
    }

    public void SetDescription1()
    {
        _card._backEffectDesc.text = _descSet[0];
    }

    public void SetDescription2()
    {
        _card._backEffectDesc.text = _descSet[1];
    }

    public void SetDescription3()
    {
        _card._backEffectDesc.text = _descSet[2];
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
}

[System.Serializable]
public class CardInfo
{
    public GameObject _cardFront;
    public GameObject _cardBack;
    public GameObject _flipButton;
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

