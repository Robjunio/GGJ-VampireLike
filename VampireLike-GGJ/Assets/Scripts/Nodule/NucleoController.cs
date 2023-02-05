using System.Collections.Generic;
using UnityEngine;

public class NucleoController
{
    private int _numberOfNucleosToWin = 4;
    private int _numberOfNucleosKilled;

    private int _nucleoBaseLife = 200;
    
    private List<Vector3> listPos = new List<Vector3>()
    {
        new Vector3(-19f,14f,0f),
        new Vector3(18f,12f,0f),
        new Vector3(16f,-10f,0f),
        new Vector3(-20f,-12f,0f)
    };
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
        
        
        _numberOfNucleosKilled++;
        if (_numberOfNucleosKilled == _numberOfNucleosToWin)
        {
            AllNucleosWasDestroyed();
        }
        else
        {
            GameController.Instance.GetEnemySpawn().GetNucleoSpawner().CreateNucleo(GetNucleoPosition());
        }
    }

    private void AllNucleosWasDestroyed()
    {
       GameController.Instance.Interface.ActivateVictoryPanel();
    }

    public Vector3 GetNucleoPosition()
    {
        var pos = Random.Range(0, listPos.Count - 1);
        var vec = listPos[pos];

        listPos.Remove(vec);

        return vec;
    }
}
