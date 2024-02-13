using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCursor : MonoBehaviour
{
    [SerializeField] private LayerMask ignoreplayermask;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.SphereCast(ray, 5, out RaycastHit hit, 1000, ignoreplayermask);

        if (hit.collider)
        {
			transform.position = hit.point;
			transform.LookAt(hit.point + hit.normal);
            transform.localScale = (Vector3.one) * Vector3.Distance(ray.origin, hit.point);
		} else
        {
            transform.position = ray.GetPoint(1000);
			transform.LookAt(ray.origin);
		}
    }
}
