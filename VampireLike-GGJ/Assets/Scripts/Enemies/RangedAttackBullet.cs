using System;
using System.Collections;
using Player;
using UnityEngine;

namespace Enemies
{
    public class RangedAttackBullet : MonoBehaviour
    {
        private float _damage;

        private void Awake()
        {
            transform.SetParent(GameObject.FindGameObjectWithTag("Gun").transform);
            _damage = GetComponentInParent<EnemyStats>().currentDamage;
            transform.SetParent(null);
            StartCoroutine(DestroyBullet());
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform.CompareTag("Player"))
            {
                col.transform.GetComponent<PlayerStats>().TakeDamage(_damage);
                Destroy(gameObject);
            }
        }

        private IEnumerator DestroyBullet()
        {
            yield return new WaitForSecondsRealtime(3f);
            Destroy(gameObject);
        }
    }
}
