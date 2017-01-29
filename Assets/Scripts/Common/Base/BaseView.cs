using UnityEngine;
using System.Collections;

public abstract class BaseView : MonoBehaviour 
{
	public abstract void SetData (params object[] datas) ;

	void Reset () 
	{
		gameObject.name = this.GetType().Name;
	}
}
