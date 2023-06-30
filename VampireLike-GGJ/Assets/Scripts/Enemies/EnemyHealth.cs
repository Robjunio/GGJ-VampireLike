using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int qntXpDroped;
    [SerializeField] private int _currentHP;
    [SerializeField] private int _maxHP;

    public void TakeDamage(int damage)
    {
        _currentHP -= damage;

        if (_currentHP <= 0)
        {
            GameController.Instance.EnemyKilled();
            GameController.Instance.GetXpDrop().CreateXpOrbs(qntXpDroped, transform);
            gameObject.GetComponent<Animator>().Play("enemy_death");
        }
    }

    public void SetLife(int value)
    {
        _maxHP = value;
        _currentHP = value;
    }
}
