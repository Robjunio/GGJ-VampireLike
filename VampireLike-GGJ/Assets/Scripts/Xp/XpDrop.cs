using UnityEngine;

public class XpDrop : MonoBehaviour
{
    [SerializeField] private GameObject orbPrefab;

    public void CreateXpOrbs(int qnt, Transform pos)
    {
        for (int i = 0; i < qnt; i++)
        {
            Instantiate(orbPrefab, pos.position, Quaternion.identity);
        }
    }
}