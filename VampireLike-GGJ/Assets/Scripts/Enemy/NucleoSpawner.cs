using UnityEngine;

public class NucleoSpawner : MonoBehaviour
{
    [SerializeField] private GameObject nucleoPrefab;
    
    // Spawn point position

    public void CreateNucleo(Vector3 pos)
    {
        var nucleo = Instantiate(nucleoPrefab, pos, Quaternion.identity);
        nucleo.GetComponent<NucleoHealth>().SetLife(GameController.Instance.GetNucleoController().GetNucleoLife());
    }
}
