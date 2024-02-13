using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Interactable, IDamagable
{
	[SerializeField] private Action action;
	[SerializeField] private Inventory inventory;
	[SerializeField] private FloatVariable health;

	[SerializeField] private GameObject hitPrefab;
	[SerializeField] private GameObject destroyPrefab;

	private void Start()
	{
		health.value = 100;
		if (action != null)
		{
			action.onEnter += OnInteractStart;
			action.onStay += OnInteractActive;
		}
	}

	private void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			inventory.Use();
		}

		if (Input.GetButtonUp("Fire1"))
		{
			inventory.StopUse();
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			inventory.NextItem();
		}

		if (Input.GetKeyDown(KeyCode.Q))
		{
			inventory.PrevItem();
		}
	}

	public void ApplyDamage(float damage)
	{
		health.value -= damage;
		Debug.Log(health.value);
		//this.health.value = Mathf.Min(this.health.value, 100);
		if (health.value <= 0)
		{
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


	public override void OnInteractActive(GameObject gameObject)
	{
		throw new System.NotImplementedException();
	}

	public override void OnInteractEnd(GameObject gameObject)
	{
		throw new System.NotImplementedException();
	}

	public override void OnInteractStart(GameObject gameObject)
	{
		throw new System.NotImplementedException();
	}
}
