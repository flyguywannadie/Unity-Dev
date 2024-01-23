using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
	[SerializeField] Animator animator;

	[SerializeField] Collider collision;
	[SerializeField] GameObject visuals;

	private void Start()
	{
		collision = GetComponent<Collider>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			animator.ResetTrigger("Reset");
			animator.SetTrigger("Activate");
			visuals.SetActive(false);
			collision.enabled = false;
			//Destroy(this.gameObject);
		}
	}


	public void Uncollect()
	{
		animator.ResetTrigger("Activate");
		visuals.SetActive(true);
		collision.enabled = true;
		animator.SetTrigger("Reset");
	}
}
