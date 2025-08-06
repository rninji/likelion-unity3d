using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pattern.Command
{
   public class PlayerController : MonoBehaviour
   {
      public Player player;
      public ICommand attackCommand, jumpCommand, skillCommand;

      private Queue<ICommand> commandQueue = new Queue<ICommand>();
      private Stack<ICommand> executeCommands = new Stack<ICommand>();

      private void Awake()
      {
         attackCommand = new AttackCommand(player);
         jumpCommand = new JumpCommand(player);
         skillCommand = new SkillCommand(player, "Fireball");
      }

      private void Update()
      {
         if (Input.GetKeyDown(KeyCode.Q)) // 공격
         {
            attackCommand.Execute();
            executeCommands.Push(attackCommand);
         }
         else if (Input.GetKeyDown(KeyCode.W)) // 점프
         {
            jumpCommand.Execute();
            executeCommands.Push(jumpCommand);
         }
         else if (Input.GetKeyDown(KeyCode.E)) // 스킬
         {
            skillCommand.Execute();
            executeCommands.Push(skillCommand);
         }
         
         if (Input.GetKeyDown(KeyCode.Z)) // 취소 - 가장 최근 명령 취소
         {
            if (executeCommands.Count > 0)
            {
               ICommand lastCommand = executeCommands.Pop();
               Debug.Log($"명령 취소 : {lastCommand.GetType().Name}");
               lastCommand.Cancel();;
            }
            else
            {
               Debug.Log("되돌릴 명령이 없습니다.");
            }
         }
         
      }
   }
}
