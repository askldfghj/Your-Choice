using UnityEngine;
using System.Collections;

public class EventObjCtrl : MonoBehaviour
{
    Vector3 _originPos;
    public TweenAlpha _tweenAlpha;

    void Awake()
    {
        _originPos = transform.localPosition;
    }

    public void OnObject()
    {
        _tweenAlpha.from = 0;
        _tweenAlpha.to = 1;
        _tweenAlpha.duration = 1;
        //<<sprite 교체코드 삽입 필요, 스프라이트를 인자로 받던가..
        _tweenAlpha.Reset();
        _tweenAlpha.Play(true);
    }

    public void CloseObject()
    {
        _tweenAlpha.from = 1;
        _tweenAlpha.to = 0;
        _tweenAlpha.duration = 1.5f;
        _tweenAlpha.Reset();
        _tweenAlpha.Play(true);
    }

    public void ObjShake()
    {
        transform.localPosition = _originPos;
        StopCoroutine("Shake");
        StartCoroutine("Shake");
    }

    IEnumerator Shake()
    {
        // How long the object should shake for.
        float shake = 0.3f;

        // Amplitude of the shake. A larger value shakes the camera harder.
        float shakeAmount = 30f;
        float decreaseFactor = 1.0f;
        while (shake > 0)
        {
            transform.localPosition = _originPos + Random.insideUnitSphere * shakeAmount;

            shake -= Time.deltaTime * decreaseFactor;
            yield return null;
        }
        shake = 0f;
        transform.localPosition = _originPos;
    }
}
