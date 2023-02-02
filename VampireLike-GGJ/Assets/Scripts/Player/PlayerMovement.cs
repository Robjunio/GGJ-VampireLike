using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [HideInInspector] public float lastHorizontalValue;
        [HideInInspector] public Vector2 direction;

        private Rigidbody2D _rb;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            InputManagement();
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void InputManagement()
        {
            float horizontalValue = Input.GetAxisRaw("Horizontal");
            float verticalValue = Input.GetAxisRaw("Vertical");
        
            direction = new Vector2(horizontalValue, verticalValue).normalized;

            if (direction.x != 0)
            {
                lastHorizontalValue = direction.x;
            }
        }

        public void Move()
        {
            _rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
        }
    }
}