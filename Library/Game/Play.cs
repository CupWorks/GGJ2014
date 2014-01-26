using System;
using UnityEngine;

namespace Library
{
	public class Play : MonoBehaviour
	{
		protected int NextScene { get; set; }

		public void Awake()
		{
			EventBus.Register(Events.SET_NEXT_SCENE, SetNextScene);
		}

		public void SetNextScene(object data)
		{
			NextScene = (int)data;
		}

		public void LevelCompleted(object data)
		{
			bool completed = (bool)data;

			if (completed)
			{
				EventBus.Push(Events.CHANGE_SCENE, NextScene);
			}
		}
	}
}

