using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject pickupEffect = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision collision)
	{
        print(collision.gameObject.name);
	}

	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Player"))
        {
            if (other.gameObject.TryGetComponent(out Player player))
            {
                player.AddPoint(10);
            }

            Instantiate(pickupEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
	}
}
