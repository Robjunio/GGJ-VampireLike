using System;
using System.Collections;
using UnityEngine;

namespace Enemies
{
    public class RangedAttackController : MonoBehaviour
    {
        [HideInInspector] public int bullets = 1;
        [SerializeField] private GameObject bulletPrefab;

        private Animator _animator;
        
        private float _attackInterval = 4f;
        private int _bulletSpeed = 5;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private IEnumerator AlternateAttack()
        {
            while (true)
            {
                Attack(1);
                yield return new WaitForSecondsRealtime(_attackInterval / bullets);
            }
        }

        private void Attack(int barrelSize)
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            Vector2 direction = (player.position - transform.position).normalized;
            StartCoroutine(Shoot(direction, barrelSize));
        }

        private IEnumerator Shoot(Vector2 direction, int barrelSize)
        {
            for (int i = 0; i < barrelSize; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.SetActive(true);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * _bulletSpeed;
                _animator.SetBool("Attack", true);
                yield return new WaitForSecondsRealtime(0.5f);
            }

            yield return new WaitForSecondsRealtime(_attackInterval);
        }
    }
}
