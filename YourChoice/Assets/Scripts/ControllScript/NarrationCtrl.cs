using UnityEngine;
using System.Collections;

public class NarrationCtrl : MonoBehaviour
{
    public StageManager _gm;
    public UITextTypeWriter _typeWriter;
    public UISprite _frame;
    public UILabel _label;
    public UIButtonMessage _narrationButton;
    public TweenAlpha _labelTween;
    public TweenAlpha _tweenalpha;

    string _text;

    void Awake()
    {
        _text = "";
        _tweenalpha.eventReceiver = gameObject;
    }

    void OnEnable()
    {
        _label.text = "";
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

    void FullTyping()
    {
        _typeWriter.FullType(_text);
        _tweenalpha.enabled = false;
        _labelTween.enabled = false;
        _frame.alpha = 0.47f;
        _label.alpha = 1f;
        _narrationButton.functionName = "NarrationTurnOff";
    }

    public void ToTurnOffButton()
    {
        _narrationButton.functionName = "NarrationTurnOff";
    }


    public void NarrationOn(string text)
    {
        _typeWriter.CoroutinesAllStop();
        _label.text = "";
        _narrationButton.functionName = "FullTyping";
        _tweenalpha.callWhenFinished = "TextTyping";
        _text = text;
        _tweenalpha.from = 0f;
        _tweenalpha.to = 0.47f;
        _labelTween.from = 0f;
        _labelTween.to = 1f;

        _tweenalpha.Reset();
        _tweenalpha.Play(true);
        _labelTween.Reset();
        _labelTween.Play(true);
    }

    void Disappear()
    {
        _tweenalpha.callWhenFinished = "NarrationTurnOff";
        _tweenalpha.from = 0.47f;
        _tweenalpha.to = 0f;
        _labelTween.from = 1f;
        _labelTween.to = 0f;

        _tweenalpha.Reset();
        _tweenalpha.Play(true);
        _labelTween.Reset();
        _labelTween.Play(true);
    }

    void NarrationTurnOff()
    {
        gameObject.SetActive(false);
    }
}
