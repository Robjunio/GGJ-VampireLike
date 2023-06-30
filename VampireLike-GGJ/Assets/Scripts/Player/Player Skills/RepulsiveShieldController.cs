using System.Collections;
using System.Collections.Generic;
using Enemies;
using Player;
using UnityEngine;

public class RepulsiveShieldController : MonoBehaviour
{
    public int damage;
    public float pushForce;
    private float _attackInterval;
    private int _level;
    private bool playerIsAlive = true;
    
    void OnEnable()
    {
        PlayerStats.WhenPlayerDied += playerDied;
    }


    void OnDisable()
    {
        PlayerStats.WhenPlayerDied -= playerDied;
    }
    
    private void playerDied()
    {
        playerIsAlive = false;
    }
    
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
                _attackInterval = 3f; // decrease shield activation interval
                break;
            case 3:
                gameObject.transform.localScale *= 1.5f; // increase shield range
                break;
            case 4:
                _attackInterval = 1f; // increase shield activation interval
                break;
            case 5:
                damage = 60; // increase shield damage
                break;
            case > 5:
                damage += 5;
                break;
        }
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            if (!playerIsAlive)
            {
                break;
            }
            transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(0.75f);
            transform.GetChild(0).gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime(_attackInterval);
        }
        
        // ReSharper disable once IteratorNeverReturns
    }
}
