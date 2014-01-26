using System;
using UnityEngine;

namespace Library
{
    public class Play : MonoBehaviour
    {
        protected int NextScene { get; set; }

        public Texture bugButton;
        public GUISkin guiSkin;

        public void Awake()
        {
            EventBus.Register(Events.SET_NEXT_SCENE, SetNextScene);
            EventBus.Register(Events.LEVEL_COMPLETED, LevelCompleted);
        }

        public void SetNextScene(object data)
        {
            NextScene = (int)data;
        }

        public void OnGUI()
        {
            GUI.skin = guiSkin;

            if (GUI.Button(new Rect(720, 0, 80, 45), bugButton))
            {
                EventBus.Push(Events.CHANGE_SCENE, NextScene);
            }
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

