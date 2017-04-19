﻿using UnityEngine;
using System.Collections;

public class PlayerObj : MonoBehaviour
{
    public static PlayerObj _current;
    public ObjectInfo _playerInfo;
    Vector3 _originPos;

    void Awake()
    {
        _originPos = transform.localPosition;
        _current = this;
        _playerInfo = new ObjectInfo("player", 30, 5, 5, 5, 1, 2);
    }

    public void Damaged(int dam)
    {
        _playerInfo._health -= dam;
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
