using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        private Transform _player;
        public float speed;

        private void Start()
        {
            _player = FindObjectOfType<PlayerMovement>().transform;
        }

        private void Update()
        {
            transform.position =
                Vector2.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);
        }
    }
}
