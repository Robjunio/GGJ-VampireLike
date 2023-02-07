using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private int _damage;

    public void Awake()
    {
        transform.SetParent(GameObject.FindGameObjectWithTag("Gun").transform);
        _damage = GetComponentInParent<GunController>().damage;
        transform.SetParent(null);
        StartCoroutine(DestroyBullet());
    }
    
    public void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.transform.tag)
        {
            case "Enemy":
                _animator.Play("Bullet");
                col.transform.GetComponent<EnemyStats>().TakeDamage(_damage);
                Destroy(gameObject, 0.3f);
                break;
            case "Nodule":
                _animator.Play("Bullet");
                col.transform.GetComponent<NucleoHealth>().TakeDamage(_damage);
                Destroy(gameObject, 0.3f);
                break;
        }
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSecondsRealtime(3f);
        Destroy(gameObject);
    }
}
