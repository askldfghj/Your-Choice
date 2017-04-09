using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITextTypeWriter : MonoBehaviour
{
    public GameObject _eventReceiver;
    public UILabel _txt;
    string _str;
    void Awake()
    {
        // TODO: add optional delay when to start
    }

    public void TypeStart(string str)
    {
        _str = str;
        _txt.text = "";
        StartCoroutine("PlayText", 0.05f);
    }
    IEnumerator PlayText(float delay)
    {
        WaitForSeconds sec = new WaitForSeconds(delay);
        for (int i = 0; i <= _str.Length; i++)
        {
            _txt.text = _str.Substring(0, i);
            yield return sec;
        }
        yield return new WaitForSeconds(3f);
        _eventReceiver.SendMessage("Disappear");
    }
}