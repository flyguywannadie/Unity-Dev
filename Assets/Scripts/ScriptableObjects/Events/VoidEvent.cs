using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/voidEvent")]
public class VoidEvent : ScriptableObjectBase
{
    public UnityAction onEventRaised;

    public void RaiseEvent()
    {
        onEventRaised?.Invoke();
    }

    public void Subscribe(UnityAction function)
    {
        onEventRaised += function;
    }

    public void UnSubscribe(UnityAction function)
    {
        onEventRaised -= function;
    }

}
