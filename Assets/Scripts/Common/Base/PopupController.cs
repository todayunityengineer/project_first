using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PopupController : MonoBehaviour 
{
	static Dictionary<string,GameObject> instances = new Dictionary<string, GameObject>();

	public static T GetOrInstantiate<T> (Transform parent = null) where T : BasePopup
	{
		string name = typeof(T).Name;

		if (instances.ContainsKey(name)) {
			return Utility.SetParent(instances[name], parent).GetComponent<T>();
		}else {
			GameObject newInstance = Utility.Instantiate(Resources.Load(R.PopupPrefix +name) as GameObject, parent);
			instances.Add(name, newInstance);
			return newInstance.GetComponent<T>();
		}
	}
}
