using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    GameObject theball;
    public Vector3 camOffset;
    public float CamSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        theball = FindAnyObjectByType<Ball>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 camoff = camOffset;
        if (Input.GetKey(KeyCode.Z))
        {
            camoff.x = 2;
            camoff.y = 0;
        }

        transform.LookAt(theball.transform.position + new Vector3(0, 1, 0));

        Vector3 lookatvector = transform.position - theball.transform.position;
        lookatvector = new Vector3(lookatvector.x, 0, lookatvector.z).normalized;

        //Debug.Log(camoff.x + " " + camoff.y);

        transform.position = Vector3.MoveTowards(transform.position, theball.transform.position + (lookatvector * camoff.x) + new Vector3(0, camoff.y,0), CamSpeed * Time.deltaTime);
    }
}
