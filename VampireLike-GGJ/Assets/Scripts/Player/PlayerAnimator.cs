using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;
        private PlayerMovement _playerMovement;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _playerMovement = GetComponent<PlayerMovement>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void Update()
        {
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
    }
}