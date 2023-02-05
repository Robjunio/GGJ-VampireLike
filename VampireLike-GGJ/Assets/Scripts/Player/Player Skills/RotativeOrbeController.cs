using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RotativeOrbeController : MonoBehaviour
{
    public int damage;
    [SerializeField] private Transform[] targets; // Refere-se aos orbes
    private const float Radius = 2.0f; // Raio da órbita
    private float _speed = 2.0f; // Velocidade da órbita
    private int _level;
    private float _attackInterval;
    private int _orbes;

    
    private void Start()
    {
        _level = 1;
        damage = 40;
        _orbes = 1;
        _attackInterval = 6f;

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
                _speed *= 3; // Increase rotation speed
                break;
            case 3:
                _attackInterval /= 2; // Faster attack speed
                break;
            case 4:
                _orbes++; // Increase number of orbes
                break;
            case 5:
                _orbes++; // Increase number of orbes
                break;
        }
    }

    void Update() {
        
        float angle = Time.time * _speed;
        Vector3 newPos1 = new Vector3(Mathf.Cos(angle) * Radius, Mathf.Sin(angle) * Radius, 0);
        Vector3 newPos2 = new Vector3(Mathf.Cos(angle + 90f) * Radius, Mathf.Sin(angle + 90f) * Radius, 0);
        Vector3 newPos3 = new Vector3(Mathf.Cos(angle + 180f) * Radius, Mathf.Sin(angle + 180f) * Radius, 0);


        var position = transform.position;
        targets[0].transform.position = position + newPos1;
        targets[1].transform.position = position + newPos2;
        targets[2].transform.position = position + newPos3;
    }


    private IEnumerator AlternatingAttack()
    {
        while (true)
        {
            Attack(_orbes);
            
            yield return new WaitForSecondsRealtime(5f);
            
            
            foreach (var target in targets)
            {
                target.gameObject.SetActive(false);
            }

            yield return new WaitForSeconds(_attackInterval);

        }
    }
    
    private void Attack(int numberOfOrbes)
    {
        targets[0].gameObject.SetActive(true);
        if (numberOfOrbes >= 2) targets[1].gameObject.SetActive(true);
        if (numberOfOrbes >= 3) targets[2].gameObject.SetActive(true);

    }
}
