using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	Vector3 initialOffset = Vector3.zero;
	Vector3 lastposition = Vector3.zero;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Player"))
		{
			initialOffset = collision.transform.position - transform.position;
			lastposition = collision.transform.position;
		}
	}

	private void OnCollisionStay(Collision collision)
	{
		if (collision.collider.CompareTag("Player"))
		{
			lastposition = collision.transform.position;
			initialOffset += collision.gameObject.GetComponent<Rigidbody>().velocity * Time.deltaTime;
			collision.transform.position = transform.position + initialOffset;
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.collider.CompareTag("Player"))
		{
			collision.gameObject.GetComponent<Rigidbody>().velocity += (collision.transform.position - lastposition)/Time.deltaTime;
		}
	}
}
