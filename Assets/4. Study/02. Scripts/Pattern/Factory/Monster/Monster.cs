using UnityEngine;

namespace Pattern.Factory
{
    public abstract class Monster : MonoBehaviour
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Attack { get; protected set; }
        
        // Monobehviour는 생성자를 쓸 수 없기 때문에 그 역할
        protected virtual void Initialize(string name, int health, int attack)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Debug.Log($"생성 : {Name} / {Health} / {Attack}");
        }
    }
}
