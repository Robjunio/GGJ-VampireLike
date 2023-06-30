using System.Collections;
using System.Collections.Generic;
using Player;
using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    public int damage;
    public int bullets;
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
        damage = 30;
        bullets = 1;
        _attackInterval = 4f;

        StartCoroutine(AlternatingAttack());
        
        // LevelUp(); // test level 2
        // LevelUp(); // test level 3
    }

    public void LevelUp()
    {
        _level++;

        switch (_level)
        {
            case 2:
                _attackInterval /= 2; // increase rate of fire
                break;
            case 3:
                bullets++; // increase number of bullets for gun spray
                break;
            case 4:
                _attackInterval /= 2; // Increase rate of fire
                break;
            case 5:
                bullets++; // Increase number of bullets for gun spray
                break;
            case > 5:
                damage += 5;
                break;
        }
    }

    private IEnumerator AlternatingAttack()
    {
        while (true)
        {
            if (!playerIsAlive)
            {
                break;
            }
            Attack(1); 
            yield return new WaitForSecondsRealtime(_attackInterval/bullets);
            if (_level >= 3)
            {
                Attack(2);
                yield return new WaitForSecondsRealtime(_attackInterval/bullets);
            }

            if (_level >= 5)
            {
                Attack(3);
                yield return new WaitForSecondsRealtime(_attackInterval/bullets);
            }
        }
        // ReSharper disable once IteratorNeverReturns
    }

    private Transform FindClosestEnemy()
    {
        // Encontre todos os inimigos na cena
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Verifique se há algum inimigo
        if (enemies.Length == 0)
        {
            return null;
        }

        // Defina o jogador mais próximo como o primeiro inimigo na lista
        Transform closest = enemies[0].transform;

        // Encontre o inimigo mais próximo
        foreach (GameObject enemy in enemies)
        {
            if (Vector2.Distance(transform.position, enemy.transform.position) <
                Vector2.Distance(transform.position, closest.position))
            {
                closest = enemy.transform;
            }
        }

        return closest;
    }

    private void Attack(int barrelSize)
    {
        var closestEnemy = FindClosestEnemy();

        if (closestEnemy == null) return;
        
        Vector2 shootDirection = (closestEnemy.position - transform.position).normalized;
        
        
        StartCoroutine(Shoot(shootDirection, barrelSize, closestEnemy));

    }

    private IEnumerator Shoot(Vector2 direction, int barrelSize, Transform closestEnemy)
    {
        var i = 0;

        while (i < barrelSize)
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform);
            bullet.SetActive(true);
            var rb = bullet.GetComponent<Rigidbody2D>();

            rb.velocity = direction * 2;
            i++;
            yield return new WaitForSecondsRealtime(0.5f);

        }

        yield return new WaitForSecondsRealtime(_attackInterval);
    }

}
