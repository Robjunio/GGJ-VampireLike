using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class XpOrb : MonoBehaviour
{
    [SerializeField] private int value;
    private Rigidbody2D _rigidbody2D;
    private Coroutine _animCoroutine;
    private void Start()
    {
        TryGetComponent(out _rigidbody2D);
        _rigidbody2D.AddForce(new Vector2(Random.Range(-3,3), 1.5f), ForceMode2D.Impulse);
        _animCoroutine = StartCoroutine(xpDropEffect());
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameController.Instance.GetXpController().AddXp(value);
            Destroy(gameObject);
        }
    }

    private IEnumerator xpDropEffect()
    {
        yield return new WaitForSeconds(Random.Range(0.4f, 0.65f));
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
    }

    private void OnDestroy()
    {
        if (_animCoroutine != null)
        {
            StopCoroutine(_animCoroutine);
        }
    }
}
