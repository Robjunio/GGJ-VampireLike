using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class RepulsiveShiled : MonoBehaviour
{
    
    private float _pushForce;
    private int _damage;

    private void OnEnable()
    {
        _damage = GetComponentInParent<RepulsiveShieldController>().damage;
        _pushForce = GetComponentInParent<RepulsiveShieldController>().pushForce;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            var enemy = col.GetComponent<EnemyStats>();
            
            enemy.TakeDamage(_damage);
            
            Vector2 pushDirection = (transform.position - col.transform.position).normalized;
            Debug.Log("Direction: " + pushDirection + "Push Force: " + _pushForce);

            StartCoroutine(PushEnemy(enemy));
        }
        else if (col.CompareTag("Nodule")) col.GetComponent<NucleoHealth>().TakeDamage(_damage);
    }

    private IEnumerator PushEnemy(EnemyStats enemy)
    {

        var enemySpeed = enemy.currentSpeed;
        
        enemy.currentSpeed *= -_pushForce;
        yield return new WaitForSecondsRealtime(0.1f);
        enemy.currentSpeed = 0;
        yield return new WaitForSecondsRealtime(0.5f);
        enemy.currentSpeed = enemySpeed;

    }



    
}
