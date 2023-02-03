using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/Player")]
    public class PlayerScriptableObject : ScriptableObject
    {
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
