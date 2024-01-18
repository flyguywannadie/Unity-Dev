using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatterManager : Singleton<SplatterManager>
{
	[SerializeField] private List<GameObject> splatters;
	[SerializeField] private int maxSplatterAmount = 50;

	public void AddSplatter(GameObject splatter)
	{
		splatters.Add(splatter);

		if (splatters.Count > maxSplatterAmount)
		{
			splatters.RemoveAt(0);
		}
	}


}
