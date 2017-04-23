using UnityEngine;
using System.Collections;

public class UIButtonCtrl : MonoBehaviour
{
    public UIBtn _statusBtn;
    public UIBtn _invenBtn;

    public Collider _narrationCol;

    Vector3 _defaultStatusTrans;
    Vector3 _defaultInvenTrans;

    void Awake()
    {
        _defaultStatusTrans = _statusBtn.btnTrans.localPosition;
        _defaultInvenTrans = _invenBtn.btnTrans.localPosition;
    }

    void StatusOpen()
    {
        StatusTweenIn();
        InvenTweenOut();
    }

    void StatusClose()
    {
        StatusTweenOut();
    }

    void InvenOpen()
    {
        StatusTweenOut();
        InvenTweenIn();
    }

    void InvenClose()
    {
        InvenTweenOut();
    }

    public void AllBtnShutDown()
    {
        StatusTweenOut();
        InvenTweenOut();
        _statusBtn.btnCollider.enabled = false;
        _invenBtn.btnCollider.enabled = false;
    }
    public void AllBtnShutOn()
    {
        _statusBtn.btnCollider.enabled = true;
        _invenBtn.btnCollider.enabled = true;
    }
    public void AllColliderShutDown()
    {
        _statusBtn.btnCollider.enabled = false;
        _invenBtn.btnCollider.enabled = false;
    }

    void StatusTweenIn()
    {
        _statusBtn.btnTween.from = _statusBtn.btnTrans.localPosition;
        _statusBtn.btnTween.to.x = -50;
        _statusBtn.btnTween.Reset();
        _statusBtn.btnTween.Play(true);
        _statusBtn.btnMessage.functionName = "StatusClose";
        _statusBtn.ConnectObj.SetActive(true);
    }
    void StatusTweenOut()
    {
        _statusBtn.btnTween.from = _statusBtn.btnTrans.localPosition;
        _statusBtn.btnTween.to = _defaultStatusTrans;
        _statusBtn.btnTween.Reset();
        _statusBtn.btnTween.Play(true);
        _statusBtn.btnMessage.functionName = "StatusOpen";
        _statusBtn.ConnectObj.SetActive(false);
    }
    void InvenTweenIn()
    {
        _invenBtn.btnTween.from = _invenBtn.btnTrans.localPosition;
        _invenBtn.btnTween.to.x = -50;
        _invenBtn.btnTween.Reset();
        _invenBtn.btnTween.Play(true);
        _invenBtn.btnMessage.functionName = "InvenClose";
        _invenBtn.ConnectObj.SetActive(true);
        _narrationCol.enabled = false;
    }
    void InvenTweenOut()
    {
        _invenBtn.btnTween.from = _invenBtn.btnTrans.localPosition;
        _invenBtn.btnTween.to = _defaultInvenTrans;
        _invenBtn.btnTween.Reset();
        _invenBtn.btnTween.Play(true);
        _invenBtn.btnMessage.functionName = "InvenOpen";
        _invenBtn.ConnectObj.SetActive(false);
        _narrationCol.enabled = true;
    }
}
[System.Serializable]
public class UIBtn
{
    public Transform btnTrans;
    public TweenPosition btnTween;
    public UIButtonMessage btnMessage;
    public Collider btnCollider;
    public GameObject ConnectObj;
}