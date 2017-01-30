using UnityEngine;
using System.Collections;

public abstract class BaseView : MonoBehaviour 
{
	protected const string EnterAnimationName = "Enter";
	protected const string ExitAnimationName = "Exit";

	protected StateTransition transition { get; private set; }

	public void SetTransition (StateTransition transition) 
	{
		this.transition = transition; 
	}

	public abstract void SetData ();

	public virtual void SetDefault(){}

	void Reset () 
	{
		gameObject.name = this.GetType().Name;
	}
}
