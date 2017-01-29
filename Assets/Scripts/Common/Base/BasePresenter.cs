using UnityEngine;
using System.Collections;

public abstract class BasePresenter : MonoBehaviour 
{
	[SerializeField] protected BaseView view;

	public void Enter (object[] datas) 
	{
		OnEnter(datas);	
	}

	protected abstract void OnEnter (object[] datas);

	public void Exit () 
	{
		OnExit();
	}

	protected abstract void OnExit ();

	void Reset () 
	{
		gameObject.name = this.GetType().Name;
		view = transform.GetComponentInChildren<BaseView>();
	}
}