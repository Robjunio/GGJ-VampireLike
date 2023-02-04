using Player;
using UnityEngine;

namespace Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        [HideInInspector] public Vector2 direction;
        
        private EnemyStats _enemy;
        public Rigidbody2D rigidbody;
        private Transform _player;

        public Rigidbody2D Rigidbody => rigidbody;

        private void Start()
        {
            _enemy = GetComponent<EnemyStats>();
            _player = FindObjectOfType<PlayerMovement>().transform;
            rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            direction = (_player.position - transform.position).normalized;
            rigidbody.velocity = direction * _enemy.currentSpeed;
        }
    }
}
