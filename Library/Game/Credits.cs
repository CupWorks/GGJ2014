using System;
using UnityEngine;

namespace Library
{
	public class Credits : MonoBehaviour
	{
		protected Rect positionOutput = new Rect(50, 480, 1000, 1200);
		protected Rect positionBackground = new Rect(0, 0, 800, 480);

		protected DialogScene DialogScene { get; set; }

		protected string output;
		public GUISkin guiSkin;
		public Texture background;

		public void Awake()
		{
			DialogScene = Serializer.Deserialize<DialogScene>("Credits.xml");
			output = "";
			positionOutput = new Rect(50, 480, 1000, 1200);

			foreach (DialogText dialogText in DialogScene.DialogTexts)
			{
				foreach (string text in dialogText.Texts)
				{
					output += text + "\n";
				}
				output += "\n";
			}
		}

		public void OnGUI()
		{
			GUI.skin = guiSkin;

			if (Input.GetMouseButtonDown(0))
			{
				EventBus.Push(Events.CHANGE_SCENE, System.LEVEL_START);
			}

			if (positionOutput.y > -1250.0f)
			{
				positionOutput.y = positionOutput.y - 0.3f;
			}
			else
			{
				EventBus.Push(Events.CHANGE_SCENE, System.LEVEL_START);
			}

			GUI.DrawTexture(positionBackground, background);
			GUI.Label(positionOutput, output);
		}
	}
}

