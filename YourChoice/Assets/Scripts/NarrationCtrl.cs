using UnityEngine;
using System.Collections;

public class NarrationCtrl : MonoBehaviour
{
    public StageManager _gm;
    public UITextTypeWriter _typeWriter;

    public TweenAlpha _labelAlpha;
    TweenAlpha _tweenalpha;

    // Use this for initialization
    void Start()
    {
        _tweenalpha = GetComponent<TweenAlpha>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TextTyping()
    {
        _typeWriter.TypeStart("당신의 첫 모험이다. 사실 이 말에는 큰 어폐가 있다.");
    }

    void Disappear()
    {
        _tweenalpha.callWhenFinished = "NarrationTurnOff";
        _tweenalpha.from = 0.47f;
        _tweenalpha.to = 0f;
        _tweenalpha.Reset();
        _tweenalpha.Play(true);
        _labelAlpha.Reset();
        _labelAlpha.Play(true);
        _gm.StartStage();
    }

    void NarrationTurnOff()
    {
        gameObject.SetActive(false);
    }
}
