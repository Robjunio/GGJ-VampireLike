using UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private HPBar _hpBar;
    [SerializeField] private int _currentHP = 1000;
    [SerializeField] private int _maxHP = 1000;

    public void TakeDamage(int damage)
    {
        _currentHP -= damage;

        if (_currentHP <= 0)
        {
            Debug.Log("Dead");
        }
        
        _hpBar.UpdateBar(_currentHP, _maxHP);
    }
}
