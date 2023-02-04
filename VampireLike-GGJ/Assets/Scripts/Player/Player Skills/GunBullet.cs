using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
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
        Debug.Log(col.transform.name);
        switch (col.transform.tag)
        {
            case "Enemy":
                col.transform.GetComponent<EnemyStats>().TakeDamage(_damage);
                break;
            case "Nodule":
                col.transform.GetComponent<NucleoHealth>().TakeDamage(_damage);
                break;
        }
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSecondsRealtime(3f);
        Destroy(this);
    }
}
