using UnityEngine;
using System.Collections;

public class TitleMainPresenter : BasePresenter 
{
	[SerializeField]UIButton btnStart;

	protected override void OnEnter (object[] datas)
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
			BaseController.LoadScene(E.Scenes.MyPage);
 		}
	}
}
