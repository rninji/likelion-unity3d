using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetCsvParser : MonoBehaviour
{
    [Serializable]
    public class CharacterData
    {
        public string charID;
        public string name;
        public int hp;
        public int attack;

        public CharacterData(string charID, string name, int hp, int attack)
        {
            this.charID = charID;
            this.name = name;
            this.hp = hp;
            this.attack = attack;
        }
    }

    public List<CharacterData> characters = new List<CharacterData>();
    public string URL;
    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);

        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        Debug.Log(data);
    }
}
