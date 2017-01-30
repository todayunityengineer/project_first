using UnityEngine;
using System.Collections;

public class TitleMainView : BaseView 
{
	[SerializeField] Animator animator;

	public override void SetData ()
	{
		animator.SetTrigger(EnterAnimationName);
	}

	public override void SetDefault ()
	{
		animator.SetTrigger(ExitAnimationName);
	}
}
