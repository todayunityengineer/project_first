using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIButton : Button 
{
	IButtonListener listener;

	void Awake () 
	{
		base.Awake();
		listener = transform.GetComponentInParent<IButtonListener>();
		if (listener != null) onClick.AddListener(() => listener.ButtonClick(gameObject));
	}
}

public interface IButtonListener 
{
	void ButtonClick(GameObject button);
}