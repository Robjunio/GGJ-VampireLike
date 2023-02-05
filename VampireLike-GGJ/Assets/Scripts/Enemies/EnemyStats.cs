using Player;
using UnityEngine;

namespace Enemies
{
    public class EnemyStats : MonoBehaviour
    {
        [HideInInspector] public float currentDamage;
        [HideInInspector] public float currentHealth;
        [HideInInspector] public float currentSpeed;
        [HideInInspector] public int currentXpDropped;
        public EnemyScriptableObject enemyData;
        public Animator enemyAnimator;
        
        
        private void Awake()
        {
            currentDamage = enemyData.Damage;
            currentHealth = enemyData.MaxHealth;
            currentSpeed = enemyData.Speed;
            currentXpDropped = enemyData.XpDropped;

            enemyAnimator = GetComponent<Animator>();
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
            GameController.Instance.GetXpDrop().CreateXpOrbs(currentXpDropped, transform);
            GameController.Instance.GetEnemySpawn().RemoveEnemyFromList(gameObject);
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
