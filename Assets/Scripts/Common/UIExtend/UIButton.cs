using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[AddComponentMenu("Button")]
public class UIButton : Button 
{
	IButtonListener listener;

	void Awake () 
	{
		base.Awake();

		listener = transform.GetComponentInParent<IButtonListener>();
		if (listener != null) onClick.AddListener(() => listener.ButtonClick(this));
		else Debug.Log(gameObject.name + " Doesn't have Listener");
	}
}

public interface IButtonListener 
{
	void ButtonClick(UIButton button);
}