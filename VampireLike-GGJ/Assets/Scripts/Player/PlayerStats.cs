using UI;
using UnityEngine;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        [HideInInspector] public float currentHealth;
        [HideInInspector] public float currentSpeed;
        [SerializeField] private float invincibilityDuration;
        [SerializeField] private HPBar hpBar;

        public PlayerScriptableObject playerData;
        private bool _isInvincible;
        private float _invincibilityTimer;

        private Animator _animator;

        private void Awake()
        {
            currentHealth = playerData.MaxHealth;
            currentSpeed = playerData.Speed;
            transform.GetChild(0).TryGetComponent(out _animator);
        }

        private void Update()
        {
            if (_invincibilityTimer > 0)
            {
                _invincibilityTimer -= Time.deltaTime;
            }
            
            else if (_isInvincible)
            {
                _isInvincible = false;
            }
        }

        public void TakeDamage(float damage)
        {
            if (!_isInvincible)
            {
                currentHealth -= damage;
                hpBar.UpdateBar(currentHealth, playerData.MaxHealth);
                
                _invincibilityTimer = invincibilityDuration;
                _isInvincible = true;

                if (currentHealth <= 0)
                {
                    Kill();
                }
            }
        }

        private void Kill()
        {
            _animator.Play("PlayerDeath");
            GameController.Instance.Interface.ActivateDefeatPanel();
        }
    }
}
