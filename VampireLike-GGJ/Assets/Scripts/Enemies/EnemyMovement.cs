using Player;
using UnityEngine;

namespace Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        [HideInInspector] public Vector2 direction;
        
        private EnemyStats _enemy;
        private Rigidbody2D _rigidbody;
        private Transform _player;

        public Rigidbody2D Rigidbody => _rigidbody;

        private void Start()
        {
            _enemy = GetComponent<EnemyStats>();
            _player = FindObjectOfType<PlayerMovement>().transform;
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            direction = (_player.position - transform.position).normalized;
            _rigidbody.velocity = direction * _enemy.currentSpeed;
        }
    }
}
