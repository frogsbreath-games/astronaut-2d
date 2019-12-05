using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SignalEvent : ScriptableObject
{
    List<SignalEventListener> Listeners = new List<SignalEventListener>();

    public void Raise()
    {
        for (int i = Listeners.Count - 1; i >= 0; i--)
        {
            Listeners[i].OnSignalEventRaise();
        }
    }
    
    public void RegisterListener(SignalEventListener listener)
    {
        Listeners.Add(listener);   
    }

    public void RemoveListener(SignalEventListener listener)
    {
        Listeners.Remove(listener);
    }
}
