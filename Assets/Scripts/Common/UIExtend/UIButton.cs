using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[AddComponentMenu("Button")]
public class UIButton : Button 
{
	IButtonListener listener;

	void Start () 
	{
		base.Start();

		listener = transform.GetComponentInParent<IButtonListener>();
		if (listener != null) onClick.AddListener(() => listener.ButtonClick(this));
		else Debug.Log(gameObject.name + " Doesn't have Listener");
	}
}

public interface IButtonListener 
{
	void ButtonClick(UIButton button);
}