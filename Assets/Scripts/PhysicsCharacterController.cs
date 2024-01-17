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
        Vector3 direction = Vector3.zero;

        direction.z = Input.GetAxis("Vertical");
        direction.x = Input.GetAxis("Horizontal");

        Quaternion yrotation = Quaternion.AngleAxis(view.rotation.eulerAngles.y,Vector3.up);
        force = yrotation * direction * maxForce;

        if (Input.GetButtonDown("Jump") && CheckGround())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(force, ForceMode.Force);
    }

    private bool CheckGround()
    {

        Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.red);
        return Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayerMask);
    }
}
