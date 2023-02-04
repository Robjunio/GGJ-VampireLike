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
        if (col.transform.tag.Equals("Enemy"))
        {
            col.transform.GetComponent<EnemyStats>().TakeDamage(_damage);
            Vector2 pushDirection = (transform.position - col.transform.position).normalized;
            float distance = Vector2.Distance(col.transform.position, transform.position);
            col.transform.GetComponent<Rigidbody2D>().AddForce(-(pushDirection * 2f * distance), ForceMode2D.Impulse);
        }
        else if(col.transform.tag.Equals("Nodule")) col.transform.GetComponent<NucleoHealth>().TakeDamage(_damage);
    }


    
}
