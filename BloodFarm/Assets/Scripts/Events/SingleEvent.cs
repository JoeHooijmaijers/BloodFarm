using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleEvent : MonoBehaviour
{
    public GameEvent[] events;

    public void RaiseEvents()
    {
        foreach(GameEvent e in events)
        {
            e.Raise();
        }
    }
}
