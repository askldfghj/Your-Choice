using UnityEngine;
using System.Collections;

public class StageLineCtrl : MonoBehaviour
{
    public float _speed;
    public UILabel _distanceLabel;
    public GameObject _character;

    int _defaultStartPosi;
    int _defaultendPosi;
    int _endPosi;

    float _distance;

    float sam;

    void Awake()
    {
        _distance = 0f;
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
            _distanceLabel.text = string.Format("{0:f0}", _distance) + "m";
            _distance += Time.deltaTime;
            yield return null;
        }
    }
}
