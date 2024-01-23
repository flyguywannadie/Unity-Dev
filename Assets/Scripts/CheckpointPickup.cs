using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointPickup : MonoBehaviour
{
	[SerializeField] GameObjectEvent respawnChange;
	[SerializeField] Collider collision;
	[SerializeField] GameObject visuals;

    // Start is called before the first frame update
    void Start()
    {
		collision = GetComponent<Collider>();   
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Activate();
		}
	}

	public void Activate()
	{
		collision.enabled = false;
		visuals.SetActive(false);
		respawnChange.RaiseEvent(this.gameObject);
	}

	public void Deactivate(GameObject newpoint)
	{
		if (newpoint != this.gameObject)
		{
			collision.enabled = true;
			visuals.SetActive(true);
		}
	}
}
