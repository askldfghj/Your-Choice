using UnityEngine;
using System.Collections;

public class EventObject
{
    public virtual EventObject Clone()
    {
        return new EventObject();
    }
}
