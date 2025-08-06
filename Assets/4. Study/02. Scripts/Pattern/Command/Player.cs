using UnityEngine;

namespace Pattern.Command
{
    public class Player : MonoBehaviour
    {
        public void Attack()
        {
            Debug.Log("Attack");
        }
        public void AttackCancel()
        {
            Debug.Log("AttackCancel");
        }
       
        public void Jump()
        {
            Debug.Log("JumpCancel");
        }
        public void JumpCancel()
        {
            Debug.Log("JumpCancel");
        }
        public void UseSkill(string skillName)
        {
            Debug.Log($"UseSkill {skillName}");
        }
        public void UseSkillCancel(string skillName)
        {
            Debug.Log($"UseSkillCancel {skillName}");
        }
    }
}
