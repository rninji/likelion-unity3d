using System;
using UnityEngine;

public class StudyFunc : MonoBehaviour
{
   
   public enum Buff { A, B, C}
   public Buff buff;

   public Func<Buff, float, float> myFunc;

   public Buff currentBuff;
   public float currentDmg;

   void Start()
   {
      myFunc?.Invoke(currentBuff, currentDmg);
   }

   float CalculationDamage(Buff buff, float dmg)
   {
      float result = 0;
      switch (buff)
      {
         case Buff.A:
            result = 10;
            break;
         case Buff.B:
            result = 20;
            break;
         case Buff.C:
            result = 30;
            break;
      }

      return dmg * result;
   }
   
}
