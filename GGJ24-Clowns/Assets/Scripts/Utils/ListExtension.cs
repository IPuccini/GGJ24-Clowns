﻿using System.Collections.Generic;

public static class ListExtension
{
	public static void Shuffle<T>(this IList<T> list)
	{
		int n = list.Count;
		while (n > 1)
		{
			n--;
			int k = UnityEngine.Random.Range(0, list.Count);
			(list[n], list[k]) = (list[k], list[n]);
		}
	}
}


