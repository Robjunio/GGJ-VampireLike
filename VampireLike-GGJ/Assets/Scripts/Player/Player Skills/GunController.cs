using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    public int damage;
    public int bullets;
    private float _attackInterval;
    private int _level;
    
    private void Start()
    {
        _level = 1;
        damage = 30;
        bullets = 1;
        _attackInterval = 3f;

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
                _attackInterval /= 2;
                break;
            case 3:
                bullets++; // Faster attack speed
                break;
            case 4:
                _attackInterval /= 2; // Increase damage
                break;
            case 5:
                bullets++; // Increase damage
                break;
        }
    }

    private IEnumerator AlternatingAttack()
    {
        while (true)
        {
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
        // Encontre todos os jogadores na cena
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Verifique se há algum jogador
        if (enemies.Length == 0)
        {
            return null;
        }

        // Defina o jogador mais próximo como o primeiro jogador na lista
        Transform closest = enemies[0].transform;

        // Encontre o jogador mais próximo
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
        
        
        StartCoroutine(Shoot(shootDirection, barrelSize));

    }

    private IEnumerator Shoot(Vector2 direction, int barrelSize)
    {
        var i = 0;

        while (i < barrelSize)
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            var rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * 2, ForceMode2D.Impulse);
            i++;

            yield return new WaitForSecondsRealtime(_attackInterval);

        }
    }

}
