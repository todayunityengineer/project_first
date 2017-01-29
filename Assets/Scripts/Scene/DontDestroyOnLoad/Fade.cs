using UnityEngine;
using System.Collections;
using System;

public sealed class Fade : MonoBehaviour 
{
	public static Fade Instance{ get; private set;}

	[SerializeField] Animator animator;

	void Awake ()
	{
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}
		
	public void Open(Action opOpenAction)
	{
		StartCoroutine(OpenAnimation(opOpenAction));
	}

	IEnumerator OpenAnimation (Action onOpenAction = null) 
	{	
		transform.transform.SetAsLastSibling();

		animator.SetTrigger("Open");
		yield return new WaitForSeconds(0.25f);

		onOpenAction.Invoke();
	}

	public void Close (Action onCloseAction)
	{
		StartCoroutine(CloseAnimation(onCloseAction));
	}

	IEnumerator CloseAnimation (Action onCloseAction)
	{
		animator.SetTrigger("Close");
		yield return new WaitForSeconds(0.25f);

		transform.transform.SetAsFirstSibling();

		onCloseAction.Invoke();
	}
}
