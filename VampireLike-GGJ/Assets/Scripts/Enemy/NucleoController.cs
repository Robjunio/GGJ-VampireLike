using UnityEngine;

public class NucleoController
{
    private int _numberOfNucleosToWin = 4;
    private int _numberOfNucleosKilled;

    private int _nucleoBaseLife = 500;

    public int GetNucleoLife()
    {
        int nucleoLife = 0;
        
        for (int i = 0; i <= _numberOfNucleosKilled; i++)
        {
            nucleoLife += _nucleoBaseLife;
        }

        return nucleoLife;
    }

    public void NucleoDestroy()
    {
        // provisório
        Vector3[] listPos = new[]
        {
            new Vector3(-3, 3, 0),
            new Vector3(2, -5, 0),
            new Vector3(-2, -1, 0)
        };
        
        _numberOfNucleosKilled++;
        if (_numberOfNucleosKilled == _numberOfNucleosToWin)
        {
            AllNucleosWasDestroyed();
        }
        else
        {
            GameController.Instance.GetEnemySpawn();
        }
    }

    private void AllNucleosWasDestroyed()
    {
       GameController.Instance.Interface.ActivateVictoryPanel();
    }

    public void GetNucleoPosition()
    {
        
    }
}
