using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerElementSpawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject elementSplatter;

    
    [SerializeField] private float pSplatTimer = 1.5f;
    private float passiveSplat;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = player.transform.position + (player.transform.up * -1 * player.gameObject.GetComponent<SphereCollider>().radius);
        passiveSplat = 0;
        SpawnSplatter(Vector3.down);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;// - (Vector3.up * player.gameObject.GetComponent<SphereCollider>().radius);

        if (OnGround())
        {
			passiveSplat -= Time.deltaTime;
			if (passiveSplat <= 0)
			{
				passiveSplat = Mathf.Clamp(pSplatTimer / player.GetComponent<Rigidbody>().velocity.magnitude, 0f, pSplatTimer);
				SpawnSplatter(Vector3.down);
			}
        }
    }

    private void SpawnSplatter(Vector3 direction)
    {
        RaycastHit hit;
        Physics.Raycast(player.transform.position + (Vector3.up * 0.9f), direction - (Vector3.up * 0.9f), out hit);

		GameObject splatter = Instantiate(elementSplatter, hit.point, Quaternion.identity);
        splatter.GetComponent<ElementSplatter>().StuckTo = hit.transform.gameObject;
        splatter.transform.LookAt(hit.point + hit.normal);
        splatter.transform.Rotate(90, 0, 0);

        splatter.transform.localScale = new Vector3(splatter.transform.localScale.x + (player.GetComponent<Rigidbody>().velocity.magnitude / 5), 1, splatter.transform.localScale.z + (player.GetComponent<Rigidbody>().velocity.magnitude / 5));
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("ElementCoverage"))
        {
            SpawnSplatter(other.ClosestPoint(transform.position) - transform.position);
        }
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("ElementCoverage"))
		{
			//SpawnSplatter();
		}
	}

    private bool OnGround()
    {
        Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, gameObject.GetComponent<SphereCollider>().bounds.extents.y);
        if (!hit.collider)
        {
            return false;
        }
        return hit.collider.CompareTag("ElementCoverage");
    }
}