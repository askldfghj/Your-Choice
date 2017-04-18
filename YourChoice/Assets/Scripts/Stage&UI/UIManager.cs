using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public UILabel _pHealthLabel;

    void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPlayerHP()
    {
        _pHealthLabel.text = PlayerObj._current._playerInfo._health.ToString();
    }
}
