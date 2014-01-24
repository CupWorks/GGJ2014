using System;
using UnityEngine;

namespace Library
{
	public class System : MonoBehaviour
	{
		public System()
		{
			EventBus.Register(Events.CHANGE_SCENE, ChangeScene);
		}

		public void Awake()
		{
			DontDestroyOnLoad(gameObject);
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
					Application.LoadLevel("Dialog");
					break;
				default:
					Debug.Log("Can't load level with ID: " + scene);
					break;
			}
		}

		public void OnGUI()
		{
			if (GUILayout.Button("Scene Main"))
			{
				EventBus.Push(Events.CHANGE_SCENE, 0);
			}
			if (GUILayout.Button("Scene Dialog 1"))
			{
				EventBus.Push(Events.CHANGE_SCENE, 0);
			}
		}
	}
}

