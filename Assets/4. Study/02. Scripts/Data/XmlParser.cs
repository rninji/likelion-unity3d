using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

public class XmlParser : MonoBehaviour
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
    [XmlRoot("Characters")]
    public class CharacterList
    {
        [XmlElement("Character")] 
        public List<CharacterData> characters;
    }

    public List<CharacterData> characterDatas = new List<CharacterData>();
    
    void Start()
    {
        TextAsset dataFile = Resources.Load<TextAsset>("XmlData");
        string data = dataFile.text;
        
        ParsingCharacterXmlData(data);
    }

    void ParsingCharacterXmlData(string data)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(CharacterList));

        using (StringReader reader = new StringReader(data))
        {
            CharacterList loadedData = (CharacterList)serializer.Deserialize(reader); // 역직렬화 + 형변환
            characterDatas = loadedData.characters;
        }

        foreach (CharacterData cData in characterDatas)
        {
            Debug.Log($"{cData.CharID} / {cData.Name} / {cData.HP} / {cData.Attack}");
        }
    }
}
