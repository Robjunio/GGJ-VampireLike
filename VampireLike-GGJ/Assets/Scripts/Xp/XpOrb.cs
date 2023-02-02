using UnityEngine;

public class XpOrb : MonoBehaviour
{
    [SerializeField] private float value;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameController.Instance.GetXpController().AddXp(value);
        }
    }
}
