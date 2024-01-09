using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("movement")]
    [SerializeField, Range(1, 20), Tooltip("force of ball")]public float force = 1;

    public Rigidbody rb;

    private void Awake()
    {
        print("awake");
    }

    // Start is called before the first frame update
    void Start()
    {
        print("start");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * force, ForceMode.VelocityChange);
        }
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movement.z += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.z -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x += 1;
        }
        rb.AddForce(Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0) * movement.normalized * force * Time.deltaTime, ForceMode.Impulse);
    }
}
