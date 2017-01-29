using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Linq;

public class AddAnimationClipEditor : Editor
{

	static UnityEditor.Animations.AnimatorController animatorController;

	static AnimatorOverrideController overrideController;

	[MenuItem("Assets/Create/Animation (in Controller)")]
	static void CreateClip ()
	{
		var animators = Selection.objects.Select(g => g as UnityEditor.Animations.AnimatorController).Where(a => a != null).ToArray();

		var overrideAnimators = Selection.objects.Select(g => g as AnimatorOverrideController).Where(a => a != null).ToArray();
	
		if (animators.Count() == 1) {
			InputWindow(animators[0]);
		} else if (overrideAnimators.Count() == 1) {
			InputWindow(overrideAnimators[0]);
		} else {
			Debug.Log("Select One Animator Controller");	
		}
	}

	static void InputWindow (UnityEditor.Animations.AnimatorController animator)
	{
		animatorController = animator;

		InputClipNameWindow.Init();
	}

	static void InputWindow (AnimatorOverrideController animator)
	{
		overrideController = animator;

		InputClipNameWindow.Init();
	}

	public static void AddEmptyClip (string clipName)
	{
		if (animatorController == null && overrideController == null)
			return;

		if (string.IsNullOrEmpty(clipName))
			return;

		if (animatorController != null) {
			if (animatorController.animationClips.Where(c => c.name == clipName).Count() > 0)
				return;

			var clip = new AnimationClip();
			clip.name = clipName;

			var fsm = animatorController.layers[0].stateMachine;
			var state = fsm.AddState(clipName);
			state.motion = clip;

			AssetDatabase.AddObjectToAsset(clip, animatorController);
			AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(clip));
		}else if (overrideController != null){
			if (overrideController.animationClips.Where(c => c.name == clipName).Count() > 0)
				return;

			var clip = new AnimationClip();
			clip.name = clipName;

			AssetDatabase.AddObjectToAsset(clip, overrideController);
			AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(clip));
		}
	}
}

public class InputClipNameWindow : EditorWindow
{

	public static void Init ()
	{
		InputClipNameWindow window = (InputClipNameWindow)EditorWindow.GetWindow(typeof(InputClipNameWindow));
		window.Show();
	}

	string clipName = "";

	void OnGUI ()
	{
		GUILayout.Label("Enter Animation Clip Name");

		clipName = EditorGUILayout.TextField("clipName", clipName);

		if (clipName != "")
		if (GUILayout.Button("Enter")) {
			InputClipNameWindow window = (InputClipNameWindow)EditorWindow.GetWindow(typeof(InputClipNameWindow));
			window.Close();

			AddAnimationClipEditor.AddEmptyClip(clipName);
		}
	}
}
