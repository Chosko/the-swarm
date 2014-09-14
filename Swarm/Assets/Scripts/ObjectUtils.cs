using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectUtils
{
	public static Dictionary<TKey, TValue> CloneDictionary<TKey, TValue>(Dictionary<TKey, TValue> original)
	{
		if (original==null)
			return null;
		
		Dictionary<TKey, TValue> ret = new Dictionary<TKey, TValue>(original.Count, original.Comparer);
		foreach (KeyValuePair<TKey, TValue> entry in original)
		{
			ret.Add(entry.Key, (TValue) entry.Value);
		}
		return ret;
	}
	
	public static List<TValue> CloneList<TValue>(List<TValue> original)
	{
		List<TValue> ret = new List<TValue>(original.Count);
		foreach (TValue entry in original)
		{
			ret.Add(entry);
		}
		
		return ret;
	}

}