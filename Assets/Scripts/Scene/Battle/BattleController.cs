using UnityEngine;
using System.Collections;

public class BattleController : BaseController 
{
	enum State 
	{
		Start = 0,
		Main = 1,
		Pause = 2,
		Result = 3,
	}

	protected override void Init ()
	{
		presenters[(int)State.Start].SetTransition(new StateTransition(
			new StateTransition.Transition(0, () => ChangePresenter((int)State.Main))
		));

		presenters[(int)State.Main].SetTransition(new StateTransition(
			new StateTransition.Transition(0, () => ChangePresenter((int)State.Pause)),
			new StateTransition.Transition(1, () => ChangePresenter((int)State.Result))
		));

		presenters[(int)State.Pause].SetTransition(new StateTransition(
			new StateTransition.Transition(0, () => ChangePresenter((int)State.Main))
		));

		presenters[(int)State.Result].SetTransition(new StateTransition(
			new StateTransition.Transition(0, () => LoadScene(E.Scenes.MyPage))
		));

		ChangePresenter((int)State.Start);
	}
}
