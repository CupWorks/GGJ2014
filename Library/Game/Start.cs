using System;
using UnityEngine;

namespace Library
{
	public class Start : MonoBehaviour
	{
		public Rect position = new Rect(200, 300, 250, 75);
		public GUISkin skin;

		public void OnGUI()
		{
			GUI.skin = skin;

			if (GUI.Button(position, "Start"))
			{
				EventBus.Push(Events.CHANGE_SCENE, System.LEVEL_DIALOG_1);
			}
		}
	}
}

