using UnityEngine;
using System.Collections;

public class PlayerObj : MonoBehaviour
{
    public static PlayerObj _current;
    public ObjectInfo _playerInfo;

    void Awake()
    {
        _current = this;
        _playerInfo = new ObjectInfo("player", 30, 5, 5, 5, 1, 2);
    }
}
