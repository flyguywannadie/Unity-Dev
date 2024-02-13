using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPart : MonoBehaviour, IDamagable
{
    [SerializeField] private Enemy main;
	[SerializeField] private float health;
	[SerializeField] private int points;
	[SerializeField] private IntEvent scoreEvent;

	[SerializeField] private GameObject hitPrefab;
	[SerializeField] private GameObject destroyPrefab;

	public void ApplyDamage(float damage)
	{
		main.ApplyDamage(damage);
		health -= damage;
		if (health <= 0)
		{
			scoreEvent?.RaiseEvent(points);
			if (destroyPrefab != null)
			{
				Instantiate(destroyPrefab, gameObject.transform.position, Quaternion.identity);
			}
			Destroy(gameObject);
		}
		else
		{
			if (hitPrefab != null)
			{
				Instantiate(hitPrefab, gameObject.transform.position, Quaternion.identity);
			}
		}
	}
}
