using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    private int _damage;

    public void Awake()
    {
        _damage = GameObject.FindGameObjectWithTag("Lightning").transform.GetComponent<LightningController>().damage;
        StartCoroutine(DestroyLightning());
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

    private IEnumerator DestroyLightning()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        Destroy(gameObject);
    }
}
