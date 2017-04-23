using UnityEngine;
using System.Collections;

public class StatusWindowCtrl : MonoBehaviour
{
    public UILabel nameLabel;
    public UILabel strLabel;
    public UILabel dexLabel;
    public UILabel intelLabel;
    public UILabel wepLabel;
    public UILabel armLabel;
    public UILabel expLabel;

    void OnEnable()
    {
        SetLabel();
    }

    public void SetLabel()
    {
        nameLabel.text = "이름: " + PlayerObj._current._playerInfo._name;
        strLabel.text = "힘: " + PlayerObj._current._playerInfo._str;
        dexLabel.text = "민첩: " + PlayerObj._current._playerInfo._dex;
        intelLabel.text = "지능: " + PlayerObj._current._playerInfo._int;
        wepLabel.text = "공격력: " + PlayerObj._current._playerInfo._wep;
        armLabel.text = "방어력: " + PlayerObj._current._playerInfo._arm;
    }
}
