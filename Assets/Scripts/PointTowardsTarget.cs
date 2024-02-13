using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTowardsTarget : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private bool player = false;

	private void Start()
	{
		if (player)
		{
			target = FindObjectOfType<PlayerShip>().gameObject;
		}
	}

	// Update is called once per frame
	void Update()
    {
        if (target)
        {
			transform.LookAt(target.transform.position);
			if (TryGetComponent(out Rigidbody rb))
			{
				rb.velocity = (transform.forward) * rb.velocity.magnitude;
			}

			if (TryGetComponent(out ProjectileAmmo pa))
			{
				if ((transform.position - target.transform.position).magnitude < 1)
				{
					Destroy(target);
					pa.OnInteractStart(target);
				}
			}
		}
    }

	public GameObject GetTarget()
	{
		return target;
	}

	public void SetTarget(GameObject t)
	{
		target = t;
	}
}
