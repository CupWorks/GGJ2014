using System;
using UnityEngine;

namespace Library
{
    public class Start : MonoBehaviour
    {
        protected Rect positionButton = new Rect(60, 300, 200, 135);
        protected Rect positionBackground = new Rect(0, 0, 800, 480);
        protected Rect positionLogo = new Rect(120, 50, 560, 338);
        public GUISkin skin;
        public Texture startButton;
        public Texture background;
        public Texture logo;

        public void OnGUI()
        {
            GUI.skin = skin;

            GUI.DrawTexture(positionBackground, background);
            GUI.DrawTexture(positionLogo, logo);
          
            if (GUI.Button(positionButton, startButton))
            {
                EventBus.Push(Events.CHANGE_SCENE, System.LEVEL_DIALOG_1);
                //EventBus.Push(Events.CHANGE_SCENE, System.LEVEL_PLAY_1);
                EventBus.Push(Events.PLAY_SOUND, System.SOUND_CLICK);
            }
        }
    }
}

