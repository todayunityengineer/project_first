using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameCharacter : MonoBehaviour 
{
	public static GameCharacter Create (Transform parent, int characterId, Color color)
	{
		GameObject go = (GameObject) Utility.Instantiate(Resources.Load<GameObject>(R.GameCharacter + characterId), parent);

		GameCharacter character = go.GetComponent<GameCharacter>();
		character.Initialize(characterId, color);
		return character;
	}

	[SerializeField,HideInInspector] Vector2[] area;
	[SerializeField] Texture2D paintAreaTexture;
	[SerializeField] Vector2 pivot;

	[SerializeField] Image characterImage;
	Color mainColor ;

	int attackDistance = 100;

	public Sprite GetIcon () 
	{
		return characterImage.sprite;
	}

	public void Initialize (int id, Color color)
	{
		mainColor = color;
		characterImage.color = mainColor;
	}

	public void PlayUpdate (ref Color[] playgroundColor)
	{
	//	Paint(transform.localPosition.ToVector2() ,transform.rotation.eulerAngles.z, attackDistance, ref playgroundColor);
	}

	void Paint (Vector2 position, float rotation, int distance, ref Color[] playgroundColor)
	{			
		Vector2 paintPivot = position 
			+ Utility.Rotate(new Vector2 (0, distance),rotation) 
			+ new Vector2(GameSetting.PlaygroundWidth, GameSetting.PlaygroundHeight)/2;

		Vector2[] paintPositions = Utility.Rotate(area, rotation);

		for (int i = 0; i < paintPositions.Length; i++) 
		{
			Vector2 pixel = paintPivot + paintPositions[i];
			if (pixel.x >= 0 && pixel.x < GameSetting.PlaygroundWidth && pixel.y >= 0 && pixel.y < GameSetting.PlaygroundHeight) {
				playgroundColor[GameSetting.PlaygroundWidth * (int)pixel.y + (int)pixel.x] = mainColor;
			}
		}
	}

}
