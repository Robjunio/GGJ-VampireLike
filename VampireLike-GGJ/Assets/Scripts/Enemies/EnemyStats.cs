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
        public Animator enemyAnimator;
        
        
        private void Awake()
        {
            currentDamage = enemyData.Damage;
            currentHealth = enemyData.MaxHealth;
            currentSpeed = enemyData.Speed;

            enemyAnimator = GetComponent<Animator>();
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            
            Debug.Log(currentHealth);

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
                enemyAnimator.SetBool("atk", true);
            }
            //enemyAnimator.SetBool("atk", false);
        }
    }
}
