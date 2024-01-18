using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/floatEvent")]
public class FloatEvent : ScriptableObjectBase
{
    public UnityAction<float> onEventRaised;

    public void RaiseEvent(float value)
    {
        onEventRaised?.Invoke(value);
    }

    public void Subscribe(UnityAction<float> function)
    {
        onEventRaised += function;
    }

    public void UnSubscribe(UnityAction<float> function)
    {
        onEventRaised -= function;
    }

}
