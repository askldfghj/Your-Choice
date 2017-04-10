using UnityEngine;
using System.Collections;

public class NarrationCtrl : MonoBehaviour
{
    public StageManager _gm;
    public UITextTypeWriter _typeWriter;

    public TweenAlpha _labelAlpha;
    public TweenAlpha _tweenalpha;

    string _text;

    void Awake()
    {
        _text = "";
        _tweenalpha.eventReceiver = gameObject;
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TextTyping()
    {
        _typeWriter.TypeStart(_text);
    }

    public void NarrationOn(string text)
    {
        _tweenalpha.callWhenFinished = "TextTyping";
        _text = text;
        _tweenalpha.from = 0f;
        _tweenalpha.to = 0.47f;
        _tweenalpha.Reset();
        _tweenalpha.Play(true);
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
