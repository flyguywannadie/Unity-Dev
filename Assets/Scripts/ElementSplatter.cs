using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSplatter : MonoBehaviour
{
    [SerializeField] private float aliveTime = 10;
    [SerializeField] private GameObject stuckto;
    private Vector3 offset;

    public GameObject StuckTo { get { return stuckto; } set { stuckto = value; offset = transform.position - stuckto.transform.position; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aliveTime -= Time.deltaTime;
        if (aliveTime <= 0)
        {
            Destroy(this.gameObject);
        }

        if (stuckto)
        {
            transform.position = stuckto.transform.position + offset;
        }
    }

    public void CleanUp()
    {
        StopAllCoroutines();
		Destroy(this.gameObject);
	}
}
