using UnityEngine;
using System.Collections;

public abstract class BasePresenter : MonoBehaviour , IButtonListener
{
	[SerializeField] protected BaseView view;

	protected bool inThisState { get; private set; }

	public void Enter (StateData datas) 
	{
		OnEnter(datas);	
		inThisState = true;
	}

	protected abstract void OnEnter (StateData datas);

	public void Exit () 
	{
		inThisState = false;
		OnExit();
	}

	protected abstract void OnExit ();

	public void ButtonClick(UIButton btn)
	{
		if (inThisState) OnButtonClick(btn);
	}

	protected abstract void OnButtonClick(UIButton btn);

	void Reset () 
	{
		gameObject.name = this.GetType().Name;
		view = transform.GetComponentInChildren<BaseView>();
	}
}