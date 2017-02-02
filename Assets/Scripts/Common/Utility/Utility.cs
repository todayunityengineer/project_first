using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public static class Utility 
{
	public static GameObject Instantiate (GameObject prefab, Transform parent, bool toParentSize = false)
	{
		GameObject go = GameObject.Instantiate(prefab) as GameObject;
		return SetParent(go, parent, toParentSize);
	}

	public static GameObject SetParent (GameObject go, Transform parent, bool toParentSize = false)
	{
		go.transform.SetParent(parent);

		go.transform.localPosition = Vector3.zero;
		go.transform.localScale = Vector3.one;
		if (parent != null) go.layer = parent.gameObject.layer;

		if (!toParentSize) return go;
		
		RectTransform rt = go.GetComponent<RectTransform>();
		if (rt != null) {
			rt.anchorMin = Vector2.zero;
			rt.anchorMax = Vector2.one;
			rt.offsetMin = Vector2.zero;
			rt.offsetMax = Vector2.one;
			rt.anchoredPosition = Vector2.zero;
		}

		return go;
	}

	public static Vector2 Rotate(Vector2 v, float degrees)
	{
		float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
		float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

		float tx = v.x;
		float ty = v.y;
		return new Vector2((cos * tx) - (sin * ty), (sin * tx) + (cos * ty));
	}

	public static Vector2[] Rotate(Vector2[] vectors, float degrees) 
	{
		float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
		float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

		List<Vector2> rotateVectors = new List<Vector2>();
		foreach (Vector2 v in vectors) {
			float tx = v.x;
			float ty = v.y;
			rotateVectors.Add (new Vector2((cos * tx) - (sin * ty),(sin * tx) + (cos * ty)));
		}
		return rotateVectors.ToArray();
	}

	public static Vector2 ToVector2(this Vector3 v)
	{
		return new Vector2(v.x, v.y);
	}

	public static Vector3 ToVector3(this Vector2 v)
	{
		return new Vector3(v.x, v.y, 0f);
	}
}
