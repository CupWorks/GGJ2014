using System;
using System.Collections.Generic;
using UnityEngine;

namespace Library
{
    public class Dialog : MonoBehaviour
    {
        protected DialogScene DialogScene { get; set; }

        protected int NextScene { get; set; }

        public List<GameObject> Characters = new List<GameObject>();
        public GUISkin skin;
        protected Dictionary<string, GameObject> loadedCharacters = new Dictionary<string, GameObject>();

        public void Awake()
        {
            EventBus.Register(Events.DIALOG_LOAD, LoadDialog);
            EventBus.Register(Events.SET_NEXT_SCENE, SetNextScene);

            foreach (GameObject character in Characters)
            {
                EventBus.Push(Events.CREATE_OBJECT, character);
                GameObject loadedCharacter = GameObject.Find(character.name);
                loadedCharacter.SetActive(false);
                loadedCharacters.Add(character.name, loadedCharacter);
            }
        }

        public void LoadDialog(object data)
        {
            int dialog = (int)data;
            DialogScene = Serializer.Deserialize<DialogScene>("DialogScene_" + dialog + ".xml");

            GameObject character;
            loadedCharacters.TryGetValue(DialogScene.GetCurrent().Speaker, out character);
            if (character != null)
            {
                character.SetActive(true);
            }
        }

        public void SetNextScene(object data)
        {
            NextScene = (int)data;
        }

        public void OnGUI()
        {
            GUI.skin = skin;

            GUI.Label(new Rect(0, 0, 500, 500), DialogScene.GetCurrent().GetCurrent());
        }

        public void OnDestroy()
        {
            EventBus.Unregister(Events.DIALOG_LOAD, LoadDialog);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                GameObject character;
                loadedCharacters.TryGetValue(DialogScene.GetCurrent().Speaker, out character);
                if (character != null)
                {
                    character.SetActive(false);
                }

                if (!DialogScene.GetCurrent().SetNext())
                {
                    if (!DialogScene.SetNext())
                    {
                        EventBus.Push(Events.CHANGE_SCENE, NextScene);
                    }
                }

                loadedCharacters.TryGetValue(DialogScene.GetCurrent().Speaker, out character);
                if (character != null)
                {
                    character.SetActive(true);
                }
            }
        }
    }
}

