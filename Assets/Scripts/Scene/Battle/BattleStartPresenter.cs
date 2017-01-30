using UnityEngine;
using System;
using System.Collections;

public class BattleStartPresenter : BasePresenter 
{
	protected override void OnEnter ()
	{
		view.SetData();
	}

	protected override void OnExit ()
	{
		view.SetDefault();
	}

	protected override void OnButtonClick (UIButton btn)
	{
		
	}
}
