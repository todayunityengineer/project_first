using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[AddComponentMenu("Text")]
public class UIText : Text 
{
	[SerializeField, HideInInspector] string localizeKey;

	IEnumerator Start () 
	{
		base.Start();
		while(!ProjectController.isLoaded) yield return new WaitForEndOfFrame();

		Localize(localizeKey);
	}

	void Localize(string key)
	{
		if (string.IsNullOrEmpty(key)) text = "";
		else text = m_localize.Get(key);
	}

	void Reset()
	{
		raycastTarget = false;
	}
}