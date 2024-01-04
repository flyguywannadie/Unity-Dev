using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disco : MonoBehaviour
{
    public Light discoLight;
    public float changetime = 1.0f;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (changetime > 0)
        {
            timer += Time.deltaTime;
            if (timer >= changetime)
            {
                discoLight.color = Random.ColorHSV();
                timer = 0;
            }
        }
    }
}
