using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
	[SerializeField] float health;
	[SerializeField] GameObject pickupPrefab;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent(out PlayerShip player))
		{
			player.ApplyDamage(0 - health);
			if (pickupPrefab != null) Instantiate(pickupPrefab, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}
