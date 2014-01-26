using System;
using UnityEngine;

namespace Library
{
	public class Image : MonoBehaviour
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

		public void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				EventBus.Push(Events.CHANGE_SCENE, NextScene);
			}
		}
	}
}

