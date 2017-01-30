using UnityEngine;
using System.Collections;

public class TitleMainView : BaseView 
{
	[SerializeField] Animator animator;

	public void OnEnter ()
	{
		animator.SetTrigger(EnterAnimationName);
	}

	public void OnExit ()
	{
		animator.SetTrigger(ExitAnimationName);
	}
}
