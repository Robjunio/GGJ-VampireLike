using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckEnemyPos : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            print("A");
        }
    }
}
