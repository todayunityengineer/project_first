using UnityEngine;
using System.Collections;

public class TitleController : BaseController 
{
	enum State 
	{
		Main = 0,	
	}

	protected override void Init ()
	{
		presenters[(int)State.Main].SetTransition(new StateTransition(
			new StateTransition.Transition(0, () => LoadScene(E.Scenes.MyPage))
		));
	
		ChangePresenter((int)State.Main);
	}
}
