using UnityEngine;

namespace Enemies
{
    
    [CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]
    public class EnemyScriptableObject : ScriptableObject
    {
        [SerializeField] private float damage;
        public float Damage
        {
            get => damage;
            private set => damage = value;
        }
        
        [SerializeField] private float maxHealth;
        public float MaxHealth
        {
            get => maxHealth;
            private set => maxHealth = value;
        }
        
        [SerializeField] private float speed;
        public float Speed
        {
            get => speed;
            private set => speed = value;
        }
    }
}