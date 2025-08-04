using System;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class StudyEventHandler : MonoBehaviour
{
   private event EventHandler handler;

   public class CharacterData : EventArgs
   {
      public string name;
      public int level;
      public float hp;
      public float mp;
      public float damage;

      public CharacterData(string name, int level, float hp, float mp, float damage)
      {
         this.name = name;
         this.level = level;
         this.hp = hp;
         this.mp = mp;
         this.damage = damage;
      }
   }

   private void Start()
   {
      handler += CreateChracter;
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         CharacterData data = new CharacterData("A", 1, 2, 3, 4);
         handler?.Invoke(this, data);
      }
   }

   void CreateChracter(object o, EventArgs e)
   {
      CharacterData data = (CharacterData)e;
      Debug.Log($"{data.name}/{data.level} 생성");
   }
}
