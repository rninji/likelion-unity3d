using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class JsonParser : MonoBehaviour
{
    [Serializable]
    public class CharacterData
    {
        public string CharID;
        public string Name;
        public int HP;
        public int Attack;
    }

    [Serializable]
    public class CharacterListWrapper
    {
        public List<CharacterData> characters; // 최상위 데이터 타입 형식
    }
    
    public List<CharacterData> characterDatas = new List<CharacterData>();
    
    void Start()
    {
        TextAsset dataFile = Resources.Load<TextAsset>("JsonData");
        string data = dataFile.text;
        
        // string data2 = File.ReadAllText(Application.dataPath + "Resources/Json/CharacterData.json"); // Application.dataPath : Resources
        
        ParsingcharacterJsonData(data);
    }

    void ParsingcharacterJsonData(string data)
    {
        CharacterListWrapper wrapper = JsonUtility.FromJson<CharacterListWrapper>(data);

        foreach (CharacterData cData in wrapper.characters)
        {
            characterDatas.Add(cData);
            Debug.Log($"{cData.CharID} / {cData.Name} / {cData.HP} / {cData.Attack}");
        }
    }
}
