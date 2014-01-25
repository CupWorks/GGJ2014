using System;
using UnityEngine;

namespace Library
{
	public class Start : MonoBehaviour
	{
		protected Rect positionButton = new Rect(30, 270, 200, 135);
		protected Rect positionBackground = new Rect(0, 0, 800, 480);
		public GUISkin skin;
		public Texture startButton;
		public Texture background;

		public void OnGUI()
		{
			GUI.skin = skin;

			GUI.DrawTexture(positionBackground, background);
          
			if (GUI.Button(positionButton, startButton))
			{
				EventBus.Push(Events.CHANGE_SCENE, System.LEVEL_DIALOG_0);
			}
		}
	}
}

