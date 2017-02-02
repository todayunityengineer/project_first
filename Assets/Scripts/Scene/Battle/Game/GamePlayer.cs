using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// 種族が増えたらabstractに変更
public class GamePlayer : MonoBehaviour, IButtonListener 
{
	public static GamePlayer Create (Transform parent, int raceId, Color color)
	{
		GameObject go = (GameObject) Utility.Instantiate(Resources.Load<GameObject>(R.GameRace + raceId), parent);

		GamePlayer player = go.GetComponent<GamePlayer>();
		player.Initialize(raceId, color);
		return player;
	}

	Color mainColor ;

	[SerializeField] UIButton btnPrefab;
	[SerializeField] Transform btnGrid;

	int[] characterIds;

	Dictionary<UIButton, int> btns = new Dictionary<UIButton, int>();
	List<GameCharacter> gameCharacters = new List<GameCharacter>();

	void Initialize (int raceId, Color color)
	{
		mainColor = color;
		characterIds = m_race.GetCharacterList(raceId);

		for (int i = 0; i < 10; i++) 
		{
			AddNewAvailableCharacter();
		}
	}

	void AddNewAvailableCharacter()
	{
		UIButton go = Utility.Instantiate(btnPrefab.gameObject, btnGrid).GetComponent<UIButton>();
		go.GetComponent<Image>().sprite = m_character.GetIcon(characterIds[btns.Count]);
		btns.Add(go, btns.Count);
	}

	public void ButtonClick(UIButton button)
	{
		gameCharacters.Add(GameCharacter.Create(transform.parent, characterIds[btns[button]], mainColor));
	}

	public void PlayUpdate (ref Color[] playgroundColor)
	{
		foreach(GameCharacter gc in gameCharacters)
		{	
			gc.PlayUpdate(ref playgroundColor);
		}
	}
}
