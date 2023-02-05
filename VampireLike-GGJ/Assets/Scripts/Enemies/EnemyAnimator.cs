using UnityEngine;

namespace Enemies
{
    public class EnemyAnimator : MonoBehaviour
    {
        private Animator _animator;
        private EnemyMovement _enemyMovement;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _enemyMovement = GetComponent<EnemyMovement>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (_enemyMovement.direction.x != 0 || _enemyMovement.direction.y != 0)
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
            _spriteRenderer.flipX = _enemyMovement.Rigidbody.velocity.x > 0;
        }
    }
}
