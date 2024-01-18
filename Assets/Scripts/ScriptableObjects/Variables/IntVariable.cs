using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[CreateAssetMenu(menuName="Variables/int")]
public class IntVariable : ScriptableObject, ISerializationCallbackReceiver
{
    public int initialValue;

    [NonSerialized]
    public int value;

    public void OnAfterDeserialize()
    {
        value = initialValue;
    }

    public void OnBeforeSerialize()
    {
        //throw new NotImplementedException();
    }
}
