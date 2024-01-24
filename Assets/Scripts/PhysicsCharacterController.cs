using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsCharacterController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField][Range(1,10)] float maxForce = 5;
    [SerializeField][Range (1,10)] float jumpForce = 5;
    [SerializeField] Transform view;
    [Header("Collision")]
    [SerializeField][Range(0,5)] float rayLength = 1;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] AudioSource jumpsound;

	Rigidbody rb;
    Vector3 force = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rayLength = GetComponent<Collider>().bounds.extents.y + 0.1f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.state == GameManager.State.MAIN_GAME)
        {
			Vector3 direction = Vector3.zero;

			direction.z = Input.GetAxis("Vertical");
			direction.x = Input.GetAxis("Horizontal");

			Quaternion yrotation = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up);
			force = yrotation * direction * maxForce;

			if (Input.GetButtonDown("Jump") && CheckGround())
			{
                jumpsound.Play();
				Vector3 jumpdirection = Vector3.up;
				Collider[] splatters = Physics.OverlapSphere(transform.position, 1.1f, groundLayerMask);
				foreach (Collider splat in splatters)
				{
					jumpdirection += splat.transform.up * jumpForce;
				}
				rb.velocity = new Vector3(rb.velocity.x, MathF.Abs(rb.velocity.y), rb.velocity.z);
				rb.AddForce(jumpdirection.normalized * jumpForce, ForceMode.Impulse);
				if (jumpdirection.normalized != Vector3.up)
				{
					rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
				}
			}
		} else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
		Collider[] sapcheck = Physics.OverlapSphere(transform.position, 1.1f);
		foreach (Collider c in sapcheck)
		{
			if (c.CompareTag("Sap"))
			{
				rb.velocity *= 0.95f;
				break;
			}
		}
		rb.AddForce(force, ForceMode.Force);
    }

    private bool CheckGround()
    {
        Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.red);
        return Physics.CheckSphere(transform.position, 1.1f, groundLayerMask);
    }

    public void Reset()
    {
        if (rb)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1.1f);
    }
}
