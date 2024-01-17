using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerElementSpawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject elementSplatter;

    
    [SerializeField] private float pSplatTimer = 1.5f;
    private float passiveSplat;
    [SerializeField] private float airtimer = 0;
    [SerializeField] private bool onGround = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position + (player.transform.up * -1 * player.gameObject.GetComponent<SphereCollider>().radius);
        passiveSplat = pSplatTimer;
        SpawnSplatter();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position - (Vector3.up * player.gameObject.GetComponent<SphereCollider>().radius);

        if (onGround && player.GetComponent<Rigidbody>().velocity.magnitude > 1)
        {
            passiveSplat -= Time.deltaTime;
            if (passiveSplat <= 0)
            {
                passiveSplat = pSplatTimer / player.GetComponent<Rigidbody>().velocity.magnitude;
                SpawnSplatter();
            }
        }
        else if(!onGround)
        {
            airtimer += Time.deltaTime;
        }
    }

    private void SpawnSplatter()
    {
		Physics.Raycast(player.transform.position, Vector3.down, out RaycastHit hit);
		GameObject splatter = Instantiate(elementSplatter, hit.point, Quaternion.identity);

        splatter.transform.localScale = new Vector3(splatter.transform.localScale.x + (airtimer/2), 1, splatter.transform.localScale.z + (airtimer / 2));
		airtimer = 0;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("ElementCoverage"))
        {
            onGround = true;
            SpawnSplatter();
        }
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("ElementCoverage"))
		{
			onGround = false;
			//SpawnSplatter();
		}
	}
}