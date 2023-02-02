using Player;
using UnityEngine;

namespace Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        private Transform _player;
        public EnemyScriptableObject enemyData;

        private void Start()
        {
            _player = FindObjectOfType<PlayerMovement>().transform;
        }

        private void Update()
        {
            transform.position = Vector2.MoveTowards(
                transform.position, 
                _player.transform.position, 
                enemyData.Speed * Time.deltaTime);
        }
    }
}
