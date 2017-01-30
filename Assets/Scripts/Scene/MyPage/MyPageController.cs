using UnityEngine;
using System.Collections;

public class MyPageController : BaseController 
{
	enum State 
	{
		Main = 0,	
	}

	protected override void Init () 
	{
	//	ChangePresenter((int)State.Main, new StateTransition(new StateTransition.Transition(0, )));
	}
}
