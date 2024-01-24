using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField][Range(-360, 360)] float angle;
    public Vector3 axis;
    float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(Random.Range(0, 360) * axis.x, Random.Range(0, 360) * axis.y, Random.Range(0, 360) * axis.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(angle * Time.deltaTime, axis);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
