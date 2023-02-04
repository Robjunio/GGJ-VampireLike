using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class RepulsiveShieldController : MonoBehaviour
{
    public int damage;
    public float pushForce;
    private float _attackInterval;
    private int _level;
    
    private void Start()
    {
        _level = 1;
        damage = 20;
        pushForce = 2f;
        _attackInterval = 5f;

        StartCoroutine(Attack());

        // LevelUp(); // test level 2
        // LevelUp(); // test level 3
        
    }

    public void LevelUp()
    {
        _level++;

        switch (_level)
        {
            case 2:
                _attackInterval = 3f;
                break;
            case 3:
                gameObject.transform.localScale *= 1.5f;
                break;
            case 4:
                _attackInterval = 1f;
                break;
            case 5:
                damage = 60;
                break;
        }
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            
            transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
            transform.GetChild(0).gameObject.SetActive(false);
            yield return new WaitForSeconds(_attackInterval);
        }
        
        // ReSharper disable once IteratorNeverReturns
    }
}
