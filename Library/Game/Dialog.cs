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
        public Texture screenTexture;
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
                loadedCharacter.transform.position = new Vector3(-6, -3, 0);
                loadedCharacter.transform.localScale = new Vector3(2.8f, 2.8f, 2.8f);
                loadedCharacter.transform.Rotate(0, 0, 10);
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

            //726, 440
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), screenTexture);
            GUI.Label(new Rect(280, 330, 1000, 1000), DialogScene.GetCurrent().GetCurrent());

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

