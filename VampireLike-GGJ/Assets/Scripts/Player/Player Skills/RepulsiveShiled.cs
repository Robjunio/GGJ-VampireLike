using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class RepulsiveShiled : MonoBehaviour
{
    
    private int _damage;

    public void OnEnable()
    {
        _damage = GetComponentInParent<RepulsiveShieldController>().damage;
    }

    
    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.transform.name);
        if(col.transform.tag.Equals("Enemy")) col.transform.GetComponent<EnemyStats>().TakeDamage(_damage);
        else if(col.transform.tag.Equals("Nodule")) col.transform.GetComponent<NucleoHealth>().TakeDamage(_damage);
    }
}
