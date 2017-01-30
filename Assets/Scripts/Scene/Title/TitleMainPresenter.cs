using UnityEngine;
using System.Collections;

public class TitleMainPresenter : BasePresenter 
{
	[SerializeField]UIButton btnStart;

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
		if (btnStart == btn) 
		{
			transition.ExecuteTransition(0);
 		}
	}
}
