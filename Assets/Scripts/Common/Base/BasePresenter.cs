using UnityEngine;
using System.Collections;

public abstract class BasePresenter : MonoBehaviour , IButtonListener
{
	#if UNITY_EDITOR
	public bool inState {
		get{
			return inThisState;
		}
	}
	#endif

	[SerializeField] protected BaseView view;

	protected bool inThisState { get; private set; }

	protected StateTransition transition { get; private set; }

	public void SetTransition (StateTransition transition)
	{
		this.transition = transition;	
	}

	public void Enter () 
	{
		OnEnter();	
		inThisState = true;
	}

	protected abstract void OnEnter ();

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