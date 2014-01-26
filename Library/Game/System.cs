using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Library
{
	public class System : MonoBehaviour
	{
		public const int LEVEL_DIALOG_1 = 0;
		public const int LEVEL_DIALOG_2 = 1;
		public const int LEVEL_DIALOG_3 = 2;
		public const int LEVEL_DIALOG_4 = 3;
		public const int LEVEL_DIALOG_5 = 4;
		public const int LEVEL_DIALOG_6 = 5;
		public const int LEVEL_DIALOG_7 = 500;
		public const int LEVEL_CREDITS = 6;
		public const int LEVEL_START = 7;
		public const int LEVEL_IMAGE_1 = 8;
		public const int LEVEL_IMAGE_2 = 9;
		public const int LEVEL_IMAGE_3 = 10;
		public const int LEVEL_IMAGE_4 = 11;
		public const int LEVEL_IMAGE_5 = 12;
		public const int LEVEL_PLAY_1 = 13;
		public const string SOUND_SMALL = "small";
		public const string SOUND_NORMAL = "normal";
		public const string SOUND_TALL = "tall";
		public const string SOUND_DEATH = "death";
		public const string SOUND_CLICK = "click";
		public GameObject start;
		public GameObject dialog;
		public GameObject credits;
		public GameObject image;
		public GameObject play;
		public GameObject[] levelBackgrounds;
		public GameObject[] playLevels;
		public bool debugMode;
		public List<AudioClip> audioFiles = new List<AudioClip>();

		protected List<Object> SceneObjects { get; set; }

		public System()
		{
			SceneObjects = new List<Object>();
		}

		public void Awake()
		{
			Screen.SetResolution(800, 480, true);

			DontDestroyOnLoad(gameObject);
			EventBus.Register(Events.CHANGE_SCENE, ChangeScene);
			EventBus.Register(Events.CREATE_OBJECT, CreateObject);
			EventBus.Register(Events.PLAY_SOUND, PlaySound);
	
			CreateObject(start);
		}

		protected void PlaySound(object data)
		{
			string name = (string)data;

			foreach (AudioClip clip in audioFiles)
			{
				if (clip.name == name)
				{
					gameObject.audio.PlayOneShot(clip);
				}
			}
		}

		protected void ChangeScene(object data)
		{
			int scene = (int)data;

			foreach (Object sceneObject in SceneObjects)
			{
				Object.Destroy(sceneObject);
			}

			switch (scene)
			{
				case LEVEL_DIALOG_1:
					CreateObject(dialog);
					EventBus.Push(Events.DIALOG_LOAD, 0);
					EventBus.Push(Events.SET_NEXT_SCENE, LEVEL_IMAGE_1);
					break;
				case LEVEL_DIALOG_2:
					CreateObject(dialog);
					EventBus.Push(Events.DIALOG_LOAD, 1);
					CreateObject(levelBackgrounds[0]);
					EventBus.Push(Events.SET_NEXT_SCENE, LEVEL_IMAGE_2);
					break;
				case LEVEL_DIALOG_3:
					CreateObject(dialog);
					EventBus.Push(Events.DIALOG_LOAD, 2);
					CreateObject(levelBackgrounds[1]);
					EventBus.Push(Events.SET_NEXT_SCENE, LEVEL_IMAGE_3);
					break;
				case LEVEL_DIALOG_4:
					CreateObject(dialog);
					EventBus.Push(Events.DIALOG_LOAD, 3);
					CreateObject(levelBackgrounds[2]);
					EventBus.Push(Events.SET_NEXT_SCENE, LEVEL_IMAGE_4);
					break;
				case LEVEL_DIALOG_5:
					CreateObject(dialog);
					EventBus.Push(Events.DIALOG_LOAD, 4);
					CreateObject(levelBackgrounds[3]);
					EventBus.Push(Events.SET_NEXT_SCENE, LEVEL_IMAGE_5);
					break;
				case LEVEL_DIALOG_6:
					CreateObject(dialog);
					EventBus.Push(Events.DIALOG_LOAD, 5);
					CreateObject(levelBackgrounds[4]);
					EventBus.Push(Events.SET_NEXT_SCENE, LEVEL_DIALOG_7);
					break;
				case LEVEL_DIALOG_7:
					CreateObject(dialog);
					EventBus.Push(Events.DIALOG_LOAD, 6);
					EventBus.Push(Events.SET_NEXT_SCENE, LEVEL_CREDITS);
					break;
				case LEVEL_CREDITS:
					CreateObject(credits);
					break;
				case LEVEL_START:
					CreateObject(start);
					break;
				case LEVEL_IMAGE_1:
					CreateObject(image);
					CreateObject(levelBackgrounds[0]);
					EventBus.Push(Events.SET_NEXT_SCENE, LEVEL_DIALOG_2);
					break;
				case LEVEL_IMAGE_2:
					CreateObject(image);
					CreateObject(levelBackgrounds[1]);
					EventBus.Push(Events.SET_NEXT_SCENE, LEVEL_DIALOG_3);
					break;
				case LEVEL_IMAGE_3:
					CreateObject(image);
					CreateObject(levelBackgrounds[2]);
					EventBus.Push(Events.SET_NEXT_SCENE, LEVEL_DIALOG_4);
					break;
				case LEVEL_IMAGE_4:
					CreateObject(image);
					CreateObject(levelBackgrounds[3]);
					EventBus.Push(Events.SET_NEXT_SCENE, LEVEL_DIALOG_5);
					break;
				case LEVEL_IMAGE_5:
					CreateObject(image);
					CreateObject(levelBackgrounds[4]);
					EventBus.Push(Events.SET_NEXT_SCENE, LEVEL_DIALOG_6);
					break;
				case LEVEL_PLAY_1:
					GameObject.Find("DefaultCamera").SetActive(false);
					CreateObject(play);
					CreateObject(playLevels[0]);
					EventBus.Push(Events.SET_NEXT_SCENE, LEVEL_DIALOG_6);
					break;
				default:
					Debug.Log("Can't load level with ID: " + scene);
					break;
			}
		}

		protected void CreateObject(object prefab)
		{
			if (prefab is Object)
			{
				GameObject newObject = (GameObject)GameObject.Instantiate((Object)prefab);
				newObject.transform.parent = gameObject.transform;
				newObject.name = newObject.name.Replace("(Clone)", "");
				SceneObjects.Add(newObject);
			}
		}

		public void OnGUI()
		{

		}
	}
}

