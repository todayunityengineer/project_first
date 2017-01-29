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
		ChangePresenter((int)State.Main);
	}
}
