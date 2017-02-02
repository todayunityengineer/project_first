using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class m_race
{
	static Dictionary<int, m_race> master = new Dictionary<int, m_race>();

	public static void Load (Master.Type masterType) 
	{
		master.Clear();

		switch (masterType) {
		case Master.Type.LoadfromFile :
			List<List<string>> csv = Master.GetCSV("m_race");
			for (int i = 0; i < csv.Count; i++) {
				master.Add(int.Parse(csv[i][0]), new m_race(csv[i]));
			}
			break;
		case Master.Type.LoadFromServer : 
			break;
		}
	}

	public static int[] GetCharacterList (int id)
	{
		return master[id].character_ids;
	}

	int id;
	string name;
	int[] character_ids;

	public m_race (List<string> data) 
	{
		this.id = int.Parse(data[0]);
		this.name = data[1];
		this.character_ids = new int[]{int.Parse(data[2]),int.Parse(data[3]),int.Parse(data[4]),int.Parse(data[5]),int.Parse(data[6]),
			int.Parse(data[7]),int.Parse(data[8]),int.Parse(data[9]),int.Parse(data[10]),int.Parse(data[11])};
	}
}
