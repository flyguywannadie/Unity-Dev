using System.Collections;using System.Collections.Generic;
using UnityEngine;

public class KinematicController : MonoBehaviour
{
    [SerializeField, Range(0, 40)] float speed = 1;
    [SerializeField] float maxDistancey = 5;
    [SerializeField] float maxDistancez = 5;
    [SerializeField] float rotationAngle = 40;
    [SerializeField] float rotationSpeed = 5;

	void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.z = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        Vector3 force = direction * speed * Time.deltaTime;
		transform.localPosition += force;

        transform.localPosition = new Vector3(0,Mathf.Clamp(transform.localPosition.y, -maxDistancey, maxDistancey), Mathf.Clamp(transform.localPosition.z, -maxDistancez, maxDistancez));
        Quaternion qyaw = Quaternion.AngleAxis(direction.x * rotationAngle, Vector3.up);
        Quaternion qpitch = Quaternion.AngleAxis(-direction.y * rotationAngle, Vector3.right);

        Quaternion rotation = qyaw * qpitch;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
