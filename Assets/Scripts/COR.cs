using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COR : MonoBehaviour
{
    [SerializeField] private float time = 3;

    IEnumerator timerCoroutine;
    public bool go;

    // Start is called before the first frame update
    void Start()
    {
        timerCoroutine = Timer(time);
        //StartCoroutine(Timer(time));
        StartCoroutine("StoryTime");
        StartCoroutine(WaitAction());
    }

    // Update is called once per frame
    void Update()
    {
        //time -= Time.deltaTime;
        //if (time <= 0)
        //{
        //    time = 3;
        //    print("Hello");
        //}
    }

    IEnumerator Timer(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            print("hello");
        }


        //yield return null;
    }

	IEnumerator StoryTime()
	{
		yield return new WaitForSeconds(1);
        print("Wolf: Lamb, tell me a story!");
		yield return new WaitForSeconds(1);
        print("Lamb: There was once a pale man with dark hair who was very lonely.");
		yield return new WaitForSeconds(1);
        print("Wolf: Why was it lonely?");
		yield return new WaitForSeconds(1);
        print("Lamb:All things must meet this man. So, they shunned him.");
		yield return new WaitForSeconds(1);
        print("Wolf: Did he chase them all?");
		yield return new WaitForSeconds(1);
        print("Lamb:He took an axe and split himself in two.");
		yield return new WaitForSeconds(1);
        print("Wolf: So he would always have a friend?");
		yield return new WaitForSeconds(1);
        print("Lamb: So he would always have a friend.");
        StartCoroutine(timerCoroutine);
	}

    IEnumerator WaitAction()
    {
        yield return new WaitWhile(() => go);
        print("go");
        yield return null;
    }
}
