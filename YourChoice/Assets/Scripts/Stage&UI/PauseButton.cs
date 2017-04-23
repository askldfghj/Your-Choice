using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour
{
    public UIButtonMessage _btn;
    public StageManager _gm;

    void Awake()
    {

    }

    void Set0()
    {
        _btn.functionName = "Set1";
        Time.timeScale = 0;
        _gm.PauseColliders();
    }

    void Set1()
    {
        _btn.functionName = "Set0";
        Time.timeScale = 1;
        _gm.ResumeColliders();
    }
}
