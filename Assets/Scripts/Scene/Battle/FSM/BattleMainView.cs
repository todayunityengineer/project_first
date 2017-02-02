using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleMainView : BaseView 
{
	Rect rect = new Rect(0, 0, GameSetting.PlaygroundWidth, GameSetting.PlaygroundHeight);
	Texture2D texture ;

	[SerializeField] Image playground;

	public void Initialize () 
	{
		texture = new Texture2D(GameSetting.PlaygroundWidth, GameSetting.PlaygroundHeight);
	}

	public void SetColor (Color[] colors)
	{
		texture.SetPixels(colors);
		texture.Apply();
		playground.sprite = Sprite.Create(texture,rect,Vector2.zero);	
	}
}
