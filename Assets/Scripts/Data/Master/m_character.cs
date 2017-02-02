using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class m_character
{
	static Dictionary<int, m_character> master = new Dictionary<int, m_character>();

	public static void Load (Master.Type masterType) 
	{
		master.Clear();

		switch (masterType) {
		case Master.Type.LoadfromFile :
			List<List<string>> csv = Master.GetCSV("m_character");
			for (int i = 0; i < csv.Count; i++) {
				master.Add(int.Parse(csv[i][0]), new m_character(csv[i]));
			}
			break;
		case Master.Type.LoadFromServer : 
			break;
		}
	}

	public static m_character Get(int id)
	{
		return master[id];
	}

	public static Sprite GetIcon(int id)
	{
		return Resources.Load<Sprite>(R.GameCharacterIcon + id);
	}

	int id;
	string name;
	int speed;

	public m_character (List<string> data) 
	{
		this.id = int.Parse(data[0]);
		this.name = data[1];
		this.speed = int.Parse(data[2]);
	}
}
