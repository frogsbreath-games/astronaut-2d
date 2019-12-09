using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Not attached to anything in the scene
//Doesn't get start or update methods, not reset on scene load
[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float InitialValue;

    [System.NonSerialized]
    public float RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize()
    {
        return; 
    }
}
