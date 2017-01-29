using UnityEngine;
using System;
using System.Collections;

public abstract class BasePopup : MonoBehaviour, IButtonListener
{
	const string OpenAnimationName = "Open";
	const string CloseAnimationName = "Close";

	[SerializeField] Animator animator;
	[SerializeField] float openAnimationTime = 0.2f;
	[SerializeField] float closeAnimationTime = 0.2f;


	protected bool isOpen { get; private set; }
	protected bool isinAnimation { get; private set; }

	public void ButtonClick(GameObject go)
	{
		if (isOpen && !isinAnimation) OnButtonClick(go);
	}

	protected abstract void OnButtonClick(GameObject go);

	protected void Open (Action onOpenAction = null)
	{
		if (isOpen){
			Debug.Log(gameObject.name + " Is Open Already");
			return;
		}
		isOpen = true;
		StartCoroutine(OpenAnimation(onOpenAction));
	}

	IEnumerator OpenAnimation (Action onOpenAction = null) 
	{	
		transform.transform.SetAsLastSibling();

		if (animator != null)
		{
			isinAnimation = true;
			animator.SetTrigger(OpenAnimationName);
			yield return new WaitForSeconds(openAnimationTime);
			isinAnimation = false;
		}

		if (onOpenAction != null) onOpenAction.Invoke();
	}

	protected void Close (Action onCloseAction = null)
	{	
		if (!isOpen){
			Debug.Log(gameObject.name + " Not Open Yet");
			return;
		}
		isOpen = false;

		StartCoroutine(CloseAnimation(onCloseAction));
	}

	IEnumerator CloseAnimation (Action onCloseAction)
	{
		if (animator != null)
		{
			isinAnimation = true;
			animator.SetTrigger(CloseAnimationName);
			yield return new WaitForSeconds(closeAnimationTime);
			isinAnimation = false;
		}

		transform.transform.SetAsFirstSibling();

		if (onCloseAction != null) onCloseAction.Invoke();
	}

	void Reset () 
	{
		name = this.GetType().Name;
		animator = GetComponent<Animator>();
	}
}
