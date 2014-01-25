using System;
using UnityEngine;

namespace Library
{
	public class Dialog : MonoBehaviour
	{
		protected DialogScene DialogScene { get; set; }

		public void Awake()
		{
			EventBus.Register(Events.DIALOG_LOAD, LoadDialog);
		}

		public void LoadDialog(object data)
		{
			int dialog = (int)data;

			DialogScene = Serializer.Deserialize<DialogScene>("DialogScene_" + dialog + ".xml");

			Debug.Log(DialogScene.DialogTexts.Count);
		}

		public void OnDestroy()
		{
			EventBus.Unregister(Events.DIALOG_LOAD, LoadDialog);
		}
	}
}

