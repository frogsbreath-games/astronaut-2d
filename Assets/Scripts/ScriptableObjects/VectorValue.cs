using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{ 
    public Vector2 InitialValue;

    [System.NonSerialized]
    public Vector2 Value;

    public void OnAfterDeserialize()
    {
        Value = InitialValue;
    }

    public void OnBeforeSerialize()
    {
        return;
    }
    // Start is called before the first frame update
}
