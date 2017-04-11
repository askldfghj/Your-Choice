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

    public void HardOff()
    {
        StopCoroutine("TextReadWait");
    }

    public void FullType(string str)
    {
        StopCoroutine("PlayText");
        _txt.text = str;
        StartCoroutine("TextReadWait");
    }

    IEnumerator TextReadWait()
    {
        yield return new WaitForSeconds(3f);
        _eventReceiver.SendMessage("Disappear");
    }

    public void TypeStart(string str)
    {
        _str = str;
        StartCoroutine("PlayText", 0.05f);
    }

    public void CoroutinesAllStop()
    {
        StopCoroutine("PlayText");
        StopCoroutine("TextReadWait");
    }
    IEnumerator PlayText(float delay)
    {
        WaitForSeconds sec = new WaitForSeconds(delay);
        for (int i = 0; i <= _str.Length; i++)
        {
            _txt.text = _str.Substring(0, i);
            yield return sec;
        }
        _eventReceiver.SendMessage("ToTurnOffButton");
        StartCoroutine("TextReadWait");
    }

   
}