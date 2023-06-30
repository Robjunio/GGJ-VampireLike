using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;
        private PlayerMovement _playerMovement;
        private SpriteRenderer _spriteRenderer;
        private bool playerIsAlive = true;
        
        void OnEnable()
        {
            PlayerStats.WhenPlayerDied += playerDied;
        }


        void OnDisable()
        {
            PlayerStats.WhenPlayerDied -= playerDied;
        }
        
        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _playerMovement = GetComponent<PlayerMovement>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void Update()
        {
            if (!playerIsAlive)
            {
                return;
            }
            
            if (_playerMovement.direction.x != 0 || _playerMovement.direction.y != 0)
            {
                _animator.SetBool("Move", true);
                CheckSpriteDirection();
            }

            else
            {
                _animator.SetBool("Move", false);
            }
        }

        private void CheckSpriteDirection()
        {
            _spriteRenderer.flipX = _playerMovement.lastHorizontalValue < 0;
        }
        
        private void playerDied()
        {
            playerIsAlive = false;
        }
    }
}