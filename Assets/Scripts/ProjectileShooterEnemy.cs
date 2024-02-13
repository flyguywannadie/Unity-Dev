using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooterEnemy : MonoBehaviour
{
    [SerializeField] private PointTowardsTarget aim;
    [SerializeField] private Transform[] shootPoints;
    [SerializeField] private Transform whereToShoot;
    [SerializeField] private GameObject hitmarkerPrefab;
    [SerializeField] private GameObject[] projectilePrefab;
    [SerializeField] private float shootDelay = 1;
    private float useddelay;
    [SerializeField] private LayerMask findPlayer;

    public int ShootPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        ShootPoint = 0;
        whereToShoot = FindObjectOfType<PathFollower>().transform;
        useddelay = shootDelay;
    }

    // Update is called once per frame
    void Update()
    {
        useddelay -= Time.deltaTime;

        if (useddelay <= 0)
        {
            Shoot();
            useddelay = shootDelay;
        }
    }

    public void Shoot()
    {
        if (!Physics.Linecast(transform.position, aim.GetTarget().transform.position, findPlayer))
        {
            GameObject hitmarker = Instantiate(hitmarkerPrefab, aim.GetTarget().transform.position, Quaternion.identity, whereToShoot);
            GameObject spawned = Instantiate(projectilePrefab[0], shootPoints[ShootPoint].transform.position, aim.transform.rotation);
            ShootPoint++;
            if (ShootPoint > shootPoints.Length - 1)
            {
                ShootPoint = 0;
            }
            spawned.GetComponent<PointTowardsTarget>().SetTarget(hitmarker);
        }
    }
}
