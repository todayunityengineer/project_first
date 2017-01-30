using UnityEngine;
using System.Collections;

public class BattleMainPresenter : BasePresenter 
{
	protected override void OnEnter ()
	{
		Debug.Log("Battle Start");
	}

	protected override void OnExit ()
	{
	}

	protected override void OnButtonClick (UIButton btn)
	{
		
	}
}
