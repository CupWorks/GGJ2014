using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Library
{
    public class System : MonoBehaviour
    {
        public GameObject dialog;

        protected List<Object> SceneObjects { get; set; }

        public System()
        {
            SceneObjects = new List<Object>();
        }

        public void Awake()
        {
            DontDestroyOnLoad(gameObject);
            EventBus.Register(Events.CHANGE_SCENE, ChangeScene);
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
                case 0:
                    SceneObjects.Add(GameObject.Instantiate(dialog));
                    EventBus.Push(Events.DIALOG_LOAD, 1);
                    break;
                case 1:
                    SceneObjects.Add(GameObject.Instantiate(dialog));
                    EventBus.Push(Events.DIALOG_LOAD, 2);
                    break;
                default:
                    Debug.Log("Can't load level with ID: " + scene);
                    break;
            }
        }

        public void OnGUI()
        {
            if (GUILayout.Button("Scene Dialog 1"))
            {
                EventBus.Push(Events.CHANGE_SCENE, 0);
            }
            if (GUILayout.Button("Scene Dialog 2"))
            {
                EventBus.Push(Events.CHANGE_SCENE, 1);
            }
        }
    }
}

