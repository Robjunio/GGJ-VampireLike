using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        
        [HideInInspector] public float lastHorizontalValue;
        [HideInInspector] public Vector2 direction;

        private PlayerStats _player;
        private Rigidbody2D _rb;

        private bool playerIsAlive = true;

        private void Awake()
        {
            _player = GetComponent<PlayerStats>();
            _rb = GetComponent<Rigidbody2D>();
        }
        void OnEnable()
        {
            PlayerStats.WhenPlayerDied += playerDied;
        }


        void OnDisable()
        {
            PlayerStats.WhenPlayerDied -= playerDied;
        }

        

        private void Update()
        {
            if (!playerIsAlive)
            {
                return;
            }
            InputManagement();
        }

        private void FixedUpdate()
        {
            if (!playerIsAlive)
            {
                return;
            }
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
            _rb.velocity = new Vector2(direction.x * _player.currentSpeed, direction.y * _player.currentSpeed);
        }

        private void playerDied()
        {
            playerIsAlive = false;
            _rb.bodyType = RigidbodyType2D.Static;
        }
    }
}