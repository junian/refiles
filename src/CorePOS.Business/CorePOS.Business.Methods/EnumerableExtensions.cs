using System;
using System.Collections.Generic;

namespace CorePOS.Business.Methods;

public static class EnumerableExtensions
{
	public static IEnumerable<T> Tail<T>(this IEnumerable<T> source, int count)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		if (count == 0)
		{
			yield break;
		}
		Queue<T> queue = new Queue<T>(count + 1);
		foreach (T item in source)
		{
			queue.Enqueue(item);
			if (queue.Count > count)
			{
				queue.Dequeue();
			}
		}
		foreach (T item2 in queue)
		{
			yield return item2;
		}
	}
}
