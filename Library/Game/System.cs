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
        public GameObject start;
        public GameObject dialog;
        public bool debugMode;

        protected List<Object> SceneObjects { get; set; }

        public System()
        {
            SceneObjects = new List<Object>();
        }

        public void Awake()
        {
            Screen.SetResolution(900, 480, true);

            DontDestroyOnLoad(gameObject);
            EventBus.Register(Events.CHANGE_SCENE, ChangeScene);
            EventBus.Register(Events.CREATE_OBJECT, CreateObject);

            CreateObject(start);
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
                    EventBus.Push(Events.DIALOG_LOAD, 1);
                    EventBus.Push(Events.SET_NEXT_SCENE, LEVEL_DIALOG_2);
                    break;
                case LEVEL_DIALOG_2:
                    CreateObject(dialog);
                    EventBus.Push(Events.DIALOG_LOAD, 2);
                    EventBus.Push(Events.SET_NEXT_SCENE, LEVEL_DIALOG_3);
                    break;
                case LEVEL_DIALOG_3:
                    CreateObject(dialog);
                    EventBus.Push(Events.DIALOG_LOAD, 3);
                    EventBus.Push(Events.SET_NEXT_SCENE, LEVEL_DIALOG_4);
                    break;
                case LEVEL_DIALOG_4:
                    CreateObject(dialog);
                    EventBus.Push(Events.DIALOG_LOAD, 4);
                    EventBus.Push(Events.SET_NEXT_SCENE, LEVEL_DIALOG_5);
                    break;
                case LEVEL_DIALOG_5:
                    CreateObject(dialog);
                    EventBus.Push(Events.DIALOG_LOAD, 5);
                    EventBus.Push(Events.SET_NEXT_SCENE, LEVEL_DIALOG_1);
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
            if (debugMode)
            {
                if (GUILayout.Button("Scene Dialog 1"))
                {
                    EventBus.Push(Events.CHANGE_SCENE, LEVEL_DIALOG_1);
                }
                if (GUILayout.Button("Scene Dialog 2"))
                {
                    EventBus.Push(Events.CHANGE_SCENE, LEVEL_DIALOG_2);
                }
                if (GUILayout.Button("Scene Dialog 3"))
                {
                    EventBus.Push(Events.CHANGE_SCENE, LEVEL_DIALOG_3);
                }
                if (GUILayout.Button("Scene Dialog 4"))
                {
                    EventBus.Push(Events.CHANGE_SCENE, LEVEL_DIALOG_5);
                }
                if (GUILayout.Button("Scene Dialog 5"))
                {
                    EventBus.Push(Events.CHANGE_SCENE, LEVEL_DIALOG_5);
                }
            }
        }
    }
}

