using System;
using UnityEngine;

public class NucleoHealth : MonoBehaviour
{
    private int _currentHP;
    private int _maxHP;


    private BoxCollider2D _boxCollider2D;
    private void Start()
    {
        TryGetComponent(out _boxCollider2D);
    }

    public void TakeDamage(int damage)
    {
        _currentHP -= damage;

        if (_currentHP <= 0)
        {
            _boxCollider2D.enabled = false;
            GameController.Instance.GetXpDrop().CreateXpOrbs((_maxHP/500) * 6 , transform);
            gameObject.GetComponent<Animator>().Play("enemy_death");
            GameController.Instance.GetEnemySpawn().GetNucleoController().NucleoDestroy();
            Destroy(gameObject, 1f);
        }
    }

    public void SetLife(int value)
    {
        _maxHP = value;
        _currentHP = value;
    }

    private void OnDestroy()
    {
        print("Removeu");
    }
}
