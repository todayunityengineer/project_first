using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public abstract class BaseController : MonoBehaviour , IButtonListener
{ 	
	// Static //

	public static BaseController Instance { get; private set; }

	public static void ProjectLoaded ()
	{
		Instance = GameObject.FindObjectOfType<BaseController>();
		Instance.Init();

		string activeSceneName = SceneManager.GetActiveScene().name;
		if (activeSceneName != E.Scenes.Blank.ToString())
		{
			Fade.Instance.Close(Instance.Initialized);
		}
	}

	// Instance //

	protected abstract void Init ();
	protected virtual void FadeClose (){}

	bool isLoaded = false;
	void Initialized()
	{
		isLoaded = true;
		FadeClose();
	}

	public void ButtonClick(GameObject go)
	{
		if (isLoaded) OnButtonClick(go);
	}

	protected abstract void OnButtonClick(GameObject go);

	[SerializeField] BasePresenter[] presenters;
	int _presentState = -1;
	protected int presentState { 
		get{
			return _presentState;
		} 
		private set{
			_presentState = value;
		} 
	}

	public void ChangePresenter (int a, params object[] datas)
	{
		if (presentState != a)
		{
			if (presentState != -1) 
			{
				presenters[presentState].Exit();
			}
			presentState = a;	
			presenters[a].Enter(datas);
		}
	}
		
	protected void LoadScene (E.Scenes nextScene)
	{
		string activeSceneName = SceneManager.GetActiveScene().name;
		if (activeSceneName == E.Scenes.Blank.ToString())
		{
			SceneManager.LoadScene(nextScene.ToString());
		}
		else 
		{
			BlankController.nextScene = nextScene;
			Fade.Instance.Open(() => SceneManager.LoadScene(E.Scenes.Blank.ToString()));
			isLoaded = false;
		}
	}

	void Reset () 
	{
		gameObject.name = this.GetType().Name;
		presenters = transform.GetComponentsInChildren<BasePresenter>();
	}
}