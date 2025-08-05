using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float damage);
}

public class StudyDecoupling : MonoBehaviour
{
    public class Player
    {

        public void AttackEnemy(IDamageable target, float damage)
        {
            target.TakeDamage(damage);
        }
    }

    public class Enemy : IDamageable
    {
        public float health = 10;

        public void TakeDamage(float damage)
        {
            health -= damage;
        }
    }
}
