using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] private BuildingSpawnPoint[] spawnPoints;
    [SerializeField] private Transform planet;
    [SerializeField] private GameObject[] buildings;
    [SerializeField] private GameObject[] defenses;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GetComponentsInChildren<BuildingSpawnPoint>();

        foreach (var spawnPoint in spawnPoints)
        {
            spawnPoint.transform.LookAt(planet);
            spawnPoint.transform.Rotate(-90,0,0);

            GameObject spawned;

			if (spawnPoint.defense)
            {
                spawned = Instantiate(defenses[Random.Range(0, defenses.Length)], spawnPoint.transform);

			} else
			{
				spawned = Instantiate(buildings[Random.Range(0, buildings.Length)], spawnPoint.transform);
			}
            spawned.transform.Rotate(0, Random.Range(0, 270), 0);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
