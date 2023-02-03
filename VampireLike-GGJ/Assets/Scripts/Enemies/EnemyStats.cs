using Player;
using UnityEngine;

namespace Enemies
{
    public class EnemyStats : MonoBehaviour
    {
        [HideInInspector] public float currentDamage;
        [HideInInspector] public float currentHealth;
        [HideInInspector] public float currentSpeed;
        public EnemyScriptableObject enemyData;

        private void Awake()
        {
            currentDamage = enemyData.Damage;
            currentHealth = enemyData.MaxHealth;
            currentSpeed = enemyData.Speed;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Kill();
            }
        }

        private void Kill()
        {
            Destroy(gameObject);
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
                player.TakeDamage(currentDamage);
            }
        }
    }
}
