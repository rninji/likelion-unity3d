using System;
using System.Collections.Generic;
using UnityEngine;

public class CsvTsvParser : MonoBehaviour
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

   private void Start()
   {
      // TextAsset dataFile = Resources.Load<TextAsset>("CsvData");
      // string data = dataFile.text;
      //
      // ParsingCharacterData(data);
      
      TextAsset dataFile = Resources.Load<TextAsset>("TsvData");
      string data = dataFile.text;
      
      ParsingCharacterData2(data);
   }

   void ParsingCharacterData(string data)
   {
      string[] rows = data.Split('\n'); // lines

      for (int i = 1; i < rows.Length; i++) // 첫번재줄 제외
      {
         string[] cols = rows[i].Split(',');

         CharacterData characterData = new CharacterData(cols[0], cols[1], int.Parse(cols[2]), int.Parse(cols[3]));
         
         characters.Add(characterData);
      }
   }
   
   void ParsingCharacterData2(string data)
   {
      string[] rows = data.Split('\n'); // lines
        
      for (int i = 1; i < rows.Length; i++)
      {
         string[] cols = rows[i].Split('\t');

         CharacterData characterData = new CharacterData(cols[0], cols[1], int.Parse(cols[2]), int.Parse(cols[3]));

         characters.Add(characterData);
      }
   }
}
