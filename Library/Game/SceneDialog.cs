using System;
using UnityEngine;

namespace Library
{
	public class SceneDialog : MonoBehaviour
	{
		protected DialogScene DialogScene{ get; set; }

		public void Start()
		{
			EventBus.Register(Events.DIALOG_SCENE_LOAD, LoadDialogSceneFile);
		}

		protected void LoadDialogSceneFile(object data)
		{
			int scene = (int)data;

			DialogScene = Serializer.Deserialize<DialogScene>("DialogScene_" + scene + ".xml");

			Debug.Log(data);
		}

		public void OnGUI()
		{
			if (DialogScene != null)
			{
				foreach (DialogText dialogText in DialogScene.DialogTexts)
				{
					foreach (string text in dialogText.Texts)
					{
						GUILayout.Label(text);
					}
				}
			}
		}
	}
}

