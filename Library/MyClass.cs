using System;
using UnityEngine;

namespace Library
{
	public class MyClass : MonoBehaviour
	{
		public MyClass()
		{

		}

		public void Awake()
		{
			EventBus.Register(0, Foo);
			EventBus.Push(0, "Foo");

			Serializer.Serialize<DialogScene>("DialogScene.xml", new DialogScene() { DialogTexts = { new DialogueText(), new DialogueText() } });
			Debug.Log(Serializer.Deserialize<DialogScene>("DialogScene.xml").DialogTexts.Count);
		}

		public void Foo(object data)
		{
			Debug.Log(data);
		}
	}
}

