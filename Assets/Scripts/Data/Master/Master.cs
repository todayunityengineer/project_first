using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public static class Master 
{
	public enum Type {
		LoadFromServer,
		LoadfromFile,
	}

	static Type masterType = Type.LoadfromFile;

	public static IEnumerator Load ()
	{
		yield return new WaitForSeconds(1f);

		m_localize.Load(masterType);
		m_race.Load(masterType);
		m_character.Load(masterType);
	}

	public static List<List<string>> GetCSV (string type)
	{
		List<List<string>> csvItems = new List<List<string>>();

		TextAsset csv = Resources.Load(string.Format("Masters/{0}", type)) as TextAsset;
		string[] lines = csv.text.Split('\n');
		for (int i = 1; i < lines.Length; i++) 
		{
			if (string.IsNullOrEmpty(lines[i])) continue;
			csvItems.Add(lines[i].Split(',').ToList());
		}
		return csvItems;
	}
}
