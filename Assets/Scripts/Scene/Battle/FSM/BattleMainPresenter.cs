using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleMainPresenter : BasePresenter 
{
	BattleMainView battleMainView;

	[SerializeField] Transform playground;
	Color[] playgroundColor = new Color[GameSetting.PlaygroundWidth * GameSetting.PlaygroundHeight];

	List<GamePlayer> player = new List<GamePlayer>();

	protected override void OnEnter ()
	{
		battleMainView = view as BattleMainView;
		battleMainView.Initialize();

		player.Clear();

		player.Add(GamePlayer.Create(playground, Random.Range(1,4), Color.red));
		if (GameSetting.PlayerCount == 2)
		{
			GamePlayer player2 = GamePlayer.Create(playground, Random.Range(1,4), Color.blue);
			player2.transform.localRotation = Quaternion.Euler(new Vector3(0,0,180));
			player.Add(player2);
		}else {
			// TODO : 画面上の方の UI
		}

		for (int w = 0; w < GameSetting.PlaygroundWidth; w++) {
			for (int h = 0; h < GameSetting.PlaygroundHeight; h++) {
				playgroundColor[h * GameSetting.PlaygroundWidth + w] = Color.white;
			}
		}
	}

	void Update () 
	{
		if (!inThisState) return;

		for (int i = 0; i < player.Count; i++) {
			player[i].PlayUpdate(ref playgroundColor);
		}

		battleMainView.SetColor(playgroundColor);
	}

	protected override void OnExit ()
	{
	}

	protected override void OnButtonClick (UIButton btn)
	{
		
	}
}
