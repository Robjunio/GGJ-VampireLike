using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class RotativeOrbe : MonoBehaviour
{    private int _damage;

    public void Awake()
    {
        _damage = GetComponentInParent<RotativeOrbeController>().damage;
    }
    
    public void OnTriggerEnter2D(Collider2D col)
    {
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

}
