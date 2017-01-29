using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BlankController : BaseController 
{
	public static E.Scenes nextScene = E.Scenes.Blank;

	protected override void OnButtonClick (GameObject go){}

	protected override void Init ()
	{
		if (nextScene == E.Scenes.Blank) 
		{
			LoadScene(E.Scenes.Title);
		}
		else 
		{
			LoadScene(nextScene);
		}
	}
}
