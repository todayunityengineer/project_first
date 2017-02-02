using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(GameCharacter))]
public class GameCharacterEditor : Editor
{
	public override void OnInspectorGUI ()
	{
		if (GUILayout.Button("SetArea"))
		{
			SerializedProperty sp = serializedObject.FindProperty("paintAreaTexture");
			SerializedProperty pivot = serializedObject.FindProperty("pivot");

			Texture2D texture = (sp.objectReferenceValue as Texture2D);

			SerializedProperty area = serializedObject.FindProperty("area");
			Vector2[] textureData = TextureDataToVector(texture, pivot.vector2Value);

			for (int i = 0; i < area.arraySize; i++) 
			{
				area.DeleteArrayElementAtIndex(i);
			}

			for (int i = 0; i < textureData.Length; i++) 
			{
				area.InsertArrayElementAtIndex(i);	
				area.GetArrayElementAtIndex(i).vector2Value = textureData[i];
			}

			serializedObject.ApplyModifiedProperties();

		}
		base.OnInspectorGUI ();
	}

	Vector2[] TextureDataToVector(Texture2D texture, Vector2 pivot)
	{
		List<Vector2> paint = new List<Vector2>();

		int width = texture.width;
		int height = texture.height;

		for (int w = 0; w < width; w++) {
			for (int h = 0; h < height; h++) {
				if (texture.GetPixel(w,h).a > 0)
				{
					paint.Add(new Vector2(w, height - h) - pivot);
				}
			}
		}
		return paint.ToArray();
	}
}
