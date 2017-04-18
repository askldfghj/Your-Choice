using UnityEngine;
using System.Collections;

public class ButtonCtrl : MonoBehaviour
{
    public CardCtrl _card;
    void OnHover(bool isOver)
    {
        if (name == "Button1")
        {
            _card.SetDescription1();
        }
        else if (name == "Button2")
        {
            _card.SetDescription2();
        }
        else if (name == "Button3")
        {
            _card.SetDescription3();
        }
    }
}
