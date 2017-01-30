using UnityEngine;
using System;
using System.Collections;

public class BattleStartView : BaseView 
{
	[SerializeField] Animator animator;
	[SerializeField] UIText txtCountdown;

	public IEnumerator CountDown(int time, Action endAction)
	{
		yield return new WaitForSeconds(1f);
		while(time != 0)
		{
			txtCountdown.text = time.ToString();
			animator.SetTrigger(EnterAnimationName);
		
			yield return new WaitForSeconds(1f);
			time --;
		}

		animator.SetTrigger(ExitAnimationName);
		endAction();
	}
}
