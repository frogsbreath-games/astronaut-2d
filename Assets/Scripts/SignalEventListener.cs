using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalEventListener : MonoBehaviour
{
    public SignalEvent Signal;
    public UnityEvent UnityEvent;

    public void OnSignalEventRaise()
    {
        UnityEvent.Invoke();
    }

    private void OnEnable()
    {
        Signal.RegisterListener(this);
    }

    private void OnDisable()
    {
        Signal.RegisterListener(this);
    }
}
