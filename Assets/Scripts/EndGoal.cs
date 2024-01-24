using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    [SerializeField] VoidEvent WinGameEvent;

	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Player"))
        {
            WinGameEvent.RaiseEvent();
        }
    }
}
