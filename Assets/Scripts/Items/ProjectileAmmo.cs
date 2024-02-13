using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileAmmo : Ammo
{
	[SerializeField] Action action;

	[SerializeField] float timer = 0;
	private bool destroyAfterLifetime = false;
	[SerializeField] private LayerMask ignoreplayermask;

	private void Start()
	{
		if (action != null)
		{
			action.onEnter += OnInteractStart;
			action.onStay += OnInteractActive;
		}

		if (ammoData.force != 0) GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * ammoData.force, ammoData.forceMode);

		if (ammoData.ammoType == AmmoType.RAYCAST)
		{
			Vector3 prevpos = transform.position;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(ray, out RaycastHit hit, 1000, ignoreplayermask);

			if (hit.collider)
			{
				transform.position = hit.point;
			} else
			{
				transform.position = ray.GetPoint(1000);
			}

			GetComponent<LineRenderer>().SetPositions(new Vector3[] { transform.position, prevpos + (ray.direction * 5) });
		}

		if (ammoData.lifetime > 0)
		{
			timer = ammoData.lifetime;
			destroyAfterLifetime = true;
		}
	}

	public override void OnInteractStart(GameObject gameObject)
	{
		if (TryGetComponent(out PointTowardsTarget ptt))
		{
			Destroy(ptt.GetTarget());
		}
		base.OnInteractStart(gameObject);
	}

	private void Update()
	{
		if (destroyAfterLifetime)
		{
			timer -= Time.deltaTime;
			if (timer <= 0)
			{
				Destroy(this.gameObject);
			}
		}

		if (ammoData.force != 0) GetComponent<Rigidbody>().velocity = transform.forward * ammoData.force;
	}
}
