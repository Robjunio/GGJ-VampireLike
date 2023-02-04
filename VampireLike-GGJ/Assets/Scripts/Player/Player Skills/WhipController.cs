using System.Collections;
using Enemies;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class WhipController : MonoBehaviour
{
    public int damage;
    private float _attackInterval;
    private int _level;
    private bool _facingRight = true;
    
    private void Start()
    {
        _level = 1;
        damage = 40;
        _attackInterval = 3f;

        StartCoroutine(AlternatingAttack());
        
        // LevelUp(); // test level 2
        // LevelUp(); // test level 3
    }

    private void Update()
    {
        // Update facing 
        if (Input.GetAxis("Horizontal") < 0) _facingRight = false;
        else if (Input.GetAxis("Horizontal") > 0) _facingRight = true;
        
    }

    public void LevelUp()
    {
        _level++;

        switch (_level)
        {
            case 3:
                _attackInterval = 1f; // Faster attack speed
                break;
            case 4:
                damage = 80; // Increase damage
                break;
            case 5:
                damage = 160; // Increase damage
                break;
        }
    }

    private IEnumerator AlternatingAttack()
    {
        while (true)
        {
            Attack(_facingRight); 
            yield return new WaitForSeconds(_attackInterval - (_attackInterval * 0.8f));

            if (_level >= 2)
            {
                Attack(!_facingRight);
                yield return new WaitForSeconds(_attackInterval - (_attackInterval * 0.8f));
                
            } else transform.GetChild(0).gameObject.SetActive(false);

            transform.GetChild(1).gameObject.SetActive(false);
            yield return new WaitForSeconds(_attackInterval);
        }
        // ReSharper disable once IteratorNeverReturns
    }

    private void Attack(bool direction)
    {
        if (direction) transform.GetChild(0).gameObject.SetActive(true);
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    
}

