using UnityEngine;
using System.Collections;

public class BattleStartView : BaseView 
{
	public override void SetData ()
	{
		StartCoroutine(CountDown(3));
	}

	IEnumerator CountDown(int time)
	{
		while(time != 0)
		{
		
			yield return new WaitForSeconds(1f);
			time --;
		}
	}

	public override void SetDefault ()
	{

	}
}
