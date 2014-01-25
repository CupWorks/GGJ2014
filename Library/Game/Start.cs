using System;
using UnityEngine;

namespace Library
{
    public class Start : MonoBehaviour
    {
        protected Rect position = new Rect(300, 300, 200, 75);
        public GUISkin skin;

        public void OnGUI()
        {
            GUI.skin = skin;

            if (GUI.Button(position, "Start"))
            {
                EventBus.Push(Events.CHANGE_SCENE, System.LEVEL_DIALOG_1);
            }
        }
    }
}

