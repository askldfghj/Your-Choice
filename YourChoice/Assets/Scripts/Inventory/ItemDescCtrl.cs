using UnityEngine;
using System.Collections;

public class ItemDescCtrl : MonoBehaviour
{
    public UILabel _name;
    public UILabel _majorpoint;
    public UILabel _majorStat;
    public Transform _windowSize;

    public void SetDesc(string name, string point, string stat)
    {
        _name.text = name;
        _majorpoint.text = point;
        _majorStat.text = stat;
    }

    public void ReLocation()
    {
        if (transform.position.x > 0 && transform.position.y > 0)
        {
            Quadrant1();
        }
        else if (transform.position.x < 0 && transform.position.y < 0)
        {
            Quadrant3();
        }
        else if (transform.position.x > 0 && transform.position.y < 0)
        {
            Quadrant4();
        }
    }

    void Quadrant1()
    {
        float adjustX = _windowSize.localScale.x;
        Vector3 pos = transform.localPosition;
        pos.x -= adjustX;
        transform.localPosition = pos;
    }
    void Quadrant2()
    {

    }
    void Quadrant3()
    {
        float adjustY = _windowSize.localScale.y;
        Vector3 pos = transform.localPosition;
        pos.y += adjustY;
        transform.localPosition = pos;
    }
    void Quadrant4()
    {
        float adjustX = _windowSize.localScale.x;
        float adjustY = _windowSize.localScale.y;
        Vector3 pos = transform.localPosition;
        pos.x -= adjustX;
        pos.y += adjustY;
        transform.localPosition = pos;
    }
}
