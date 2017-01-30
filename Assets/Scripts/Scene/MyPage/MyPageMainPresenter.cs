﻿using UnityEngine;
using System.Collections;

public class MyPageMainPresenter : BasePresenter 
{
	[SerializeField] UIButton btnBattle;

	protected override void OnEnter ()
	{

	}

	protected override void OnExit ()
	{

	}

	protected override void OnButtonClick (UIButton btn)
	{
		if (btn == btnBattle) 
		{
			transition.ExecuteTransition(0);
		}	
	}
}
