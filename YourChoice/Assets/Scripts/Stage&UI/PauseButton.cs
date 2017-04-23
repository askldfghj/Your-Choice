using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour
{
    public GameObject _curtain;
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
        _curtain.SetActive(true);
    }

    void Set1()
    {
        _btn.functionName = "Set0";
        Time.timeScale = 1;
        _gm.ResumeColliders();
        _curtain.SetActive(false);
    }
}
