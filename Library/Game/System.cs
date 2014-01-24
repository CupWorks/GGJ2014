using System;
using UnityEngine;

namespace Library
{
	public class System
	{
		public System()
		{
			EventBus.Register(Events.CHANGE_SCENE, ChangeScene);
		}

		public void ChangeScene(object data)
		{
			int scene = (int)data;

			switch (scene)
			{
				case 0:
					Application.LoadLevel("Main");
					break;
				case 1:
					Application.LoadLevel("Level");
					break;
				default:
					Debug.Log("Can't load level with ID: " + scene);
					break;
			}
		}
	}
}

