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
        }

        public void OnGUI()
        {
            GUI.Label(new Rect(100, 100, 300, 300), DialogScene.GetCurrent().GetCurrent());
        }

        public void OnDestroy()
        {
            EventBus.Unregister(Events.DIALOG_LOAD, LoadDialog);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (!DialogScene.GetCurrent().SetNext())
                {
                    DialogScene.SetNext();
                }
            }
        }
    }
}

