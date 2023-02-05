using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class LightningController : MonoBehaviour
{
   [SerializeField] private GameObject lightningPrefab;
    public int damage;
    public int lightnings;
    private float _attackInterval;
    private int _level;
    private bool _isFirstIteration = true;
    
    private void Start()
    {
        _level = 1;
        damage = 40;
        lightnings = 1;
        _attackInterval = 6f;

        StartCoroutine(AlternatingAttack());

        _isFirstIteration = false;

        // LevelUp(); // test level 2
        // LevelUp(); // test level 3
    }

    public void LevelUp()
    {
        _level++;

        switch (_level)
        {
            case 2:
                damage = 60; // Increase lightning damage
                break;
            case 3:
                _attackInterval /= 2; // Faster attack speed
                break;
            case 4:
                lightnings++; // Increase number of lightnings for strike
                break;
            case 5:
                lightnings++; // Increase number of lightnings for strike
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
            
            if (_isFirstIteration) yield return new WaitForSecondsRealtime(3f);
            else{
                Attack(1); 
                yield return new WaitForSecondsRealtime(_attackInterval/lightnings);
                if (_level >= 4)
                {
                    Attack(2);
                    yield return new WaitForSecondsRealtime(_attackInterval/lightnings);
                }

                if (_level >= 5)
                {
                    Attack(3);
                    yield return new WaitForSecondsRealtime(_attackInterval/lightnings);
                }
            
            }
        }
        // ReSharper disable once IteratorNeverReturns
    }

    private Transform FindRandomEnemy()
    {
        // Encontre todos os inimigos na cena
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Verifique se há algum inimigo
        if (enemies.Length == 0)
        {
            return null;
        }

        // Escolhe um inimigo aleatório do array
        var randomIndex = Random.Range(0, enemies.Length);
        var randomEnemy = enemies[randomIndex];
        

        return randomEnemy.transform;
    }

    private void Attack(int numberOfLightnings)
    {
        StartCoroutine(Strike(numberOfLightnings));

    }

    private IEnumerator Strike(int numberOfLightnings)
    {
        var i = 0;

        while (i < numberOfLightnings)
        {
            
            var randomEnemy = FindRandomEnemy();

            if (randomEnemy == null) yield return null;
            else
            {

                var lightning = Instantiate(
                    lightningPrefab, randomEnemy.transform.position + Vector3.up * 2, Quaternion.identity);
                lightning.SetActive(true);
                var rb = lightning.GetComponent<Rigidbody2D>();

                yield return new WaitForSecondsRealtime(0.25f);
            }

            i++;
        }

        yield return new WaitForSecondsRealtime(_attackInterval);
    }
}
