using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject pickupEffect = null;
    [SerializeField] GameObject visuals;
    [SerializeField] Collider collision;

    [SerializeField] private int pointstoadd = 1;

	private void Start()
	{
		collision = GetComponent<Collider>();
	}

	private void OnCollisionEnter(Collision collision)
	{
        print(collision.gameObject.name);//
	}

	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Player"))
        {
            if (other.gameObject.TryGetComponent(out Player player))
            {
                player.AddPoint(pointstoadd);
            }

            Instantiate(pickupEffect, transform.position, Quaternion.identity);
            visuals.SetActive(false);
            collision.enabled = false;
            //Destroy(this.gameObject);
        }
	}

    public void Uncollect()
    {
        visuals.SetActive(true);
		collision.enabled = true;
	}
}
