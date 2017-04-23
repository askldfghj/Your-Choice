using UnityEngine;
using System.Collections;

public class StageLineCtrl : MonoBehaviour
{
    public float _speed;

    public GameObject _character;

    int _defaultStartPosi;
    int _defaultendPosi;
    int _endPosi;

    void Awake()
    {
        _defaultStartPosi = -150;
        _defaultendPosi = 120;
        _endPosi = _defaultendPosi;
    }

    void Start()
    {
        _character.transform.localPosition = new Vector3(_defaultStartPosi, 23, 0);
    }

    public void StartRun()
    {
        StartCoroutine("Run");
    }

    public void PauseRun()
    {
        StopCoroutine("Run");
    }

    IEnumerator Run()
    {
        while (_character.transform.position.x < _endPosi)
        {
            _character.transform.Translate(_speed * Time.deltaTime, 0, 0);
            yield return null;
        }
    }
}
