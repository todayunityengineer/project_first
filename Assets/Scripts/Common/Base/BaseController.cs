using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public abstract class BaseController : MonoBehaviour
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

	public static void ChangePresenter (int a)
	{
		if (Instance.presentState != a)
		{
			if (Instance.presentState != -1) 
			{
				Instance.presenters[Instance.presentState].Exit();
			}
			Instance.presentState = a;	
			Instance.presenters[a].Enter();
		}
	}

	public static void LoadScene (E.Scenes nextScene)
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
			Instance.isLoaded = false;
		}
	}
		
	// Instance //

	protected abstract void Init ();
	protected virtual void FadeClose (){}

	public bool isLoaded { get; private set; }
	void Initialized()
	{
		isLoaded = true;
		FadeClose();
	}

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

	void Reset () 
	{
		gameObject.name = this.GetType().Name;
		presenters = transform.GetComponentsInChildren<BasePresenter>();
	}
}